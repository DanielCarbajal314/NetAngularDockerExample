using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.Infrastructure.Queu.Bootstrap
{
    public interface IRabbitWrapperConfiguration
    {
        public string RabbitUserName { get; }
        public string RabbitPassword { get; }
        public string RabbitHost { get; }
    }
}
