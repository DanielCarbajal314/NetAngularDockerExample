using Photo.Domain.Persistency.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.Domain.Persistency
{
    public interface IUnitOfWork
    {
        IPhotoImageRepository PhotoImageRepository { get; }
        Task BeginTransaction();
        Task Complete();
    }
}
