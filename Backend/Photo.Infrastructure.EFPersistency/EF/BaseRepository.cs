using Microsoft.EntityFrameworkCore;
using Photo.Domain.Common;
using Photo.Domain.Persistency.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.Infrastructure.EFPersistency.EF
{
    public class BaseRepository<T> : DbContextContainer, IRepository<T> where T : class
    {
        public BaseRepository(PhotoDbContext db) : base(db)
        {
        }

        public async Task Delete(T entity)
        {
            this._db.Entry(entity).State = EntityState.Deleted;
        }

        public async Task<T> FindById(int id)
        {
            return await this._db.Set<T>().FindAsync(id) ?? throw new PhotoNonFoundException("Entity was not found on the database");
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await this._db.Set<T>().ToListAsync();
        }

        public async Task<T> Register(T entity)
        {
            this._db.Set<T>().Add(entity);
            return entity;
        }

        public async Task Update(T entity)
        {
            this._db.Entry(entity).State = EntityState.Modified;
        }
    }
}
