using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.Infrastructure.EFPersistency.Bootstrap
{
    public static class ConnectionStringBuilder
    {
        public static string BuildSQLServerConnectionString(this ISqlEnviromentSettings configuration)
        {
            return $@"
                data source={configuration.Host},{configuration.Port};
                initial catalog={configuration.Catalog};
                user id={configuration.Username};
                password={configuration.Password};
            ";
        }
    }
}
