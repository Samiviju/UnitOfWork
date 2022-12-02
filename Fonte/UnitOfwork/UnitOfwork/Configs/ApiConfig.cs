using DataAccessEF;
using Microsoft.EntityFrameworkCore;
using UnitOfwork.Middleware;
using Utils;

namespace UnitOfwork.Configs
{
    public static class ApiConfig
    {
        private readonly static string DbConnection;
        static  ApiConfig()
        {
            DbConnection = new SecretsManager().ConnectionStringLocal;
        }
        public static IServiceCollection AddConfigurationApi(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddControllers();
            services.AddHttpContextAccessor();

            services.AddCors(options =>
            {
                options.AddPolicy("Development",
                    builder =>
                        builder
                        .AllowAnyMethod()
                        .WithOrigins("http://localhost:53424/*")
                        .AllowAnyHeader());
            });

            return services;
        }

        public static IServiceCollection DbStringConnection(this IServiceCollection services)
        {
            var connection = services.AddDbContext<PeopleContext>(options => options.UseSqlServer(DbConnection));
            return connection;
        }

        public static IApplicationBuilder UsingConfigurationApi(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors("Development");
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseMiddleware(typeof(ErrorHandlerMiddleware));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
                });
            });

            return app;
        }
    }
}