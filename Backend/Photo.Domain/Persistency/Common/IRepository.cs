using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.Domain.Persistency.Common
{
    public interface IRepository<T>
    {
        Task<T> FindById(int id);
        Task<T> Register(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<IEnumerable<T>> GetAll();
    }
}
