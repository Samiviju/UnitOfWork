using DataAccessEF.UnitOfWork;
using Domain.Interfaces;
using Services;

namespace UnitOfwork.Configs
{
    public static class DependencyInjectionSetup
    {
        public static IServiceCollection ResolveDependency(this IServiceCollection services)
        {
            services.AddScoped<IServiceLog, ServiceLog>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}