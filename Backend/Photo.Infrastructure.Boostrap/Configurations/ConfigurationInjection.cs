using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Photo.Infrastructure.AWS.Bootstrap;
using Photo.Infrastructure.Boostrap.Sources;
using Photo.Infrastructure.EFPersistency.Bootstrap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.Infrastructure.Boostrap.Configurations
{
    internal static class ConfigurationInjection
    {
        public static IServiceCollection SetupSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = new ConfigurationInjector(configuration);
            services.AddSingleton<ISqlEnviromentSettings>(provider => settings);
            services.AddSingleton<IAwsSettings>(provider => settings);
            return services;
        }

        public static IPhotoSettings BuildGlobalSettings(this IConfiguration configuration)
        {
            return new ConfigurationInjector(configuration);
        }
    }
}
