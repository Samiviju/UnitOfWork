using DataAccessEF;
using Microsoft.EntityFrameworkCore;
using UnitOfwork.Configs;
using UnitOfwork.Configuracoes;
using Utils;

namespace UnitOfwork
{
    public class Startup
    {
        

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddConfigurationApi(Configuration);
            services.ResolveDependency();
            services.AddSwaggerSettings();
            services.DbStringConnection();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UsingConfigurationApi(env);
            app.UsingBuildsSwagger(env);
        }
    }
}