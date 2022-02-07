using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.Infrastructure.Queu.Bootstrap
{
    internal static class RabbitConnectionString
    {
        public static string BuildConnectionString(this IRabbitWrapperConfiguration configuration)
        {
            return $"host={configuration.RabbitHost};username={configuration.RabbitUserName};password={configuration.RabbitPassword}";
        }
    }
}
