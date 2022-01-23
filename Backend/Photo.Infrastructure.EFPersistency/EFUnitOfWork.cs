using Microsoft.EntityFrameworkCore.Storage;
using Photo.Domain.Persistency;
using Photo.Domain.Persistency.Repositories;
using Photo.Infrastructure.EFPersistency.EF;
using Photo.Infrastructure.EFPersistency.Repositories;

namespace Photo.Infrastructure.EFPersistency
{
    public class EFUnitOfWork : DbContextContainer, IUnitOfWork
    {
        private IDbContextTransaction? _transaction;
        public IPhotoImageRepository PhotoImageRepository { get; private set; }

        public EFUnitOfWork(PhotoDbContext db):base(db) 
        {
            this.PhotoImageRepository = new PhotoImageRepository(db);
        }

        public async Task BeginTransaction()
        {
            this._transaction = await _db.Database.BeginTransactionAsync();
        }

        public async Task Complete()
        {
            if (this._transaction != null)
            {
                _transaction.Commit();
            }
            await _db.SaveChangesAsync();
        }
    }
}