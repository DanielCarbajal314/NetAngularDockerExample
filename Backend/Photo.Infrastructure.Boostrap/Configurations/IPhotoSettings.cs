using Photo.Infrastructure.AWS.Bootstrap;
using Photo.Infrastructure.EFPersistency.Bootstrap;
using Photo.Infrastructure.Queu.Bootstrap;

namespace Photo.Infrastructure.Boostrap.Configurations
{
    public interface IPhotoSettings : ISqlEnviromentSettings, IAwsSettings, IRabbitWrapperConfiguration
    {

    }
}
