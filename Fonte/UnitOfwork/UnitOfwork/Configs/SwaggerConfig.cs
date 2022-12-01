using Microsoft.OpenApi.Models;

namespace UnitOfwork.Configuracoes
{
    public static class SwaggerConfig
    {
        public static IApplicationBuilder UsingBuildsSwagger(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsEnvironment("Local"))
            {
                app.UseSwagger(c =>
                {
                    c.RouteTemplate = "/api-docs/{documentName}/swagger.json";
                });

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("v1/swagger.json", "UnitOfwork");
                    c.RoutePrefix = "api-docs";
                });
            }

            return app;
        }

        public static IServiceCollection AddSwaggerSettings(this IServiceCollection services)
        {
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo { Title = "UnitOfwork" });
                var documentacaoWebAPI = Path.Combine(AppContext.BaseDirectory, "UnitOfwork");
                var documentacaoDominioWebAPI = Path.Combine(AppContext.BaseDirectory, "Domain");
                swagger.IncludeXmlComments(documentacaoWebAPI);
                swagger.IncludeXmlComments(documentacaoDominioWebAPI);

                swagger.AddSecurityDefinition("Autorização", new OpenApiSecurityScheme
                {
                    Description = "Insira a api key da aplicação",
                    Name = "x-api-key",
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Autorização"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            return services;
        }
    }
}