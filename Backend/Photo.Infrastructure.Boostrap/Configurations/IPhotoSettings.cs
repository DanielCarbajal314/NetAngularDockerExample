using Photo.Infrastructure.AWS.Bootstrap;
using Photo.Infrastructure.EFPersistency.Bootstrap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.Infrastructure.Boostrap.Configurations
{
    public interface IPhotoSettings : ISqlEnviromentSettings, IAwsSettings
    {

    }
}
