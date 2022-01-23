using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.Infrastructure.EFPersistency.Bootstrap
{
    public interface ISqlEnviromentSettings
    {
        string Host { get; }
        string Port { get; }
        string Catalog { get; }
        string Username { get; }
        string Password { get; }
    }
}
