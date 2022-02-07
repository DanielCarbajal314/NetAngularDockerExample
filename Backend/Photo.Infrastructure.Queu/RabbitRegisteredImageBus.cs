using Photo.Domain.External.Queu;
using Photo.Infrastructure.Queu.Common;
using Photo.Domain.External.Queu.DTO;
using Photo.Infrastructure.Queu.Bootstrap;

namespace Photo.Infrastructure.Queu
{
    public class RabbitRegisteredImageBus : RabbitMqBus<RegisteredImage>, IRegisteredImageBus
    {
        public RabbitRegisteredImageBus(IRabbitWrapperConfiguration configuration) : base(configuration)
        {
        }
    }
}