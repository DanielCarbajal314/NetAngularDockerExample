using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Photo.Domain.Persistency;
using Photo.Infrastructure.EFPersistency;
using Photo.Infrastructure.EFPersistency.Bootstrap;
using Photo.Infrastructure.EFPersistency.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.Infrastructure.Boostrap.Configurations
{
    internal static class SQLServerPersistency
    {
        public static IServiceCollection SetupSqlServerPersistency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PhotoDbContext>(options =>
            {
                var connectionString = configuration.BuildGlobalSettings().BuildSQLServerConnectionString();
                options.UseSqlServer(connectionString);
            });
            services.AddTransient<IUnitOfWork, EFUnitOfWork>();
            return services;
        }
    }
}
