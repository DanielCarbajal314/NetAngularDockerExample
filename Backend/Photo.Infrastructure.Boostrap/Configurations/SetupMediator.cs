using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.Infrastructure.Boostrap.Configurations
{
    internal static class SetupMediator
    {
        public static IServiceCollection BootstrapMediator(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("Photo.BusinessLogic");
            services.AddMediatR(assembly);
            return services;
        }
    }
}
