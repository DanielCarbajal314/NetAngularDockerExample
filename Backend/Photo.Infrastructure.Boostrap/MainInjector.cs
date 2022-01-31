using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Photo.Infrastructure.Boostrap.Configurations;

namespace Photo.Infrastructure.Boostrap
{
    public static class MainInjector
    {
        public static IServiceCollection BoostrapApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.SetupSqlServerPersistency(configuration);
            services.SetupSettings(configuration);
            services.BoostrapAWS();
            services.BootstrapMediator();
            return services;
        }

    }
}