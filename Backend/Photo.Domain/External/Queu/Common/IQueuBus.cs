using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.Domain.External.Queu.Common
{
    public interface IQueuBus<T> where T : class
    {
        Task Queu(T TEvent);
        Task Dequeue(string subcriptionId, Func<T, Task> action);
    }
}
