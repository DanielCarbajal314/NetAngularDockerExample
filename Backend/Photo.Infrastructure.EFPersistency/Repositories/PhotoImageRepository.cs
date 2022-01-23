using Microsoft.EntityFrameworkCore;
using Photo.Domain.Entities;
using Photo.Domain.Persistency.Repositories;
using Photo.Infrastructure.EFPersistency.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.Infrastructure.EFPersistency.Repositories
{
    public class PhotoImageRepository : BaseRepository<PhotoImage>, IPhotoImageRepository
    {
        public PhotoImageRepository(PhotoDbContext db) : base(db) { }

        public Task<bool> SignatureExist(string signature)
        {
            return this._db.Set<PhotoImage>().AnyAsync(x => x.Signature.Equals(signature));
        }
    }
}
