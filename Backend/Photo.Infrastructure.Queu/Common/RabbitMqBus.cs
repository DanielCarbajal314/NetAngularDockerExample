using EasyNetQ;
using Photo.Domain.External.Queu.Common;
using Photo.Infrastructure.Queu.Bootstrap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.Infrastructure.Queu.Common
{
    public class RabbitMqBus<T> : IQueuBus<T> where T : class
    {
        protected IBus _bus;

        public RabbitMqBus(IRabbitWrapperConfiguration configuration)
        {
            _bus = RabbitHutch.CreateBus(configuration.BuildConnectionString());

        }

        public async Task Dequeue(string subscriptionId, Func<T, Task> action)
        {
            await _bus.PubSub.SubscribeAsync<T>(subscriptionId, action);
        }

        public async Task Queu(T TEvent)
        {
            await _bus.PubSub.PublishAsync(TEvent);
        }
    }
}
