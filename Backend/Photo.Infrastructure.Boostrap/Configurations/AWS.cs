using Microsoft.Extensions.DependencyInjection;
using Photo.Domain.External.File;
using Photo.Infrastructure.AWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.Infrastructure.Boostrap.Configurations
{
    internal static class AWS
    {
        public static IServiceCollection BoostrapAWS(this IServiceCollection services)
        {
            services.AddSingleton<IFileRepository, S3FileRepository>();
            return services;
        }
    }
}
