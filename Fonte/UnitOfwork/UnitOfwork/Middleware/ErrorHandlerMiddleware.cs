using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace UnitOfwork.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IServiceLog log)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, log);
            }
        }

        internal async Task HandleExceptionAsync(HttpContext context, Exception exception, IServiceLog log)
        {
            if (!context.Response.HasStarted)
            {
                Guid identificadorLog = Guid.NewGuid();

                var erro = $"Source: {exception.Source} | Message: {exception.Message} | StackTrace: {exception.StackTrace}";
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                ProblemDetails detalhesDoProblema = new();
                detalhesDoProblema.Status = StatusCodes.Status500InternalServerError;
                detalhesDoProblema.Type = "InternalServerError";
                detalhesDoProblema.Title = exception.Source;
                detalhesDoProblema.Detail = erro;

                await log.GravarLogAsync(detalhesDoProblema, identificadorLog);

                detalhesDoProblema.Title = "Erro interno da aplicação.";
                detalhesDoProblema.Detail = $"Entre contato e informe o codigo {identificadorLog}";

                await context.Response.WriteAsync(JsonConvert.SerializeObject(detalhesDoProblema));
            }
        }
    }
}