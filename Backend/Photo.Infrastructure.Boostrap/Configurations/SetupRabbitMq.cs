using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Photo.Domain.External.Queu;
using Photo.Infrastructure.Queu;
using Photo.Infrastructure.Queu.Bootstrap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.Infrastructure.Boostrap.Configurations
{
    internal static class SetupRabbitMq
    {
        public static IServiceCollection BootstrapRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = configuration.BuildGlobalSettings();
            services.AddSingleton<IRabbitWrapperConfiguration>(settings);
            services.AddSingleton<IRegisteredImageBus, RabbitRegisteredImageBus>();
            return services;
        }
    }
}
