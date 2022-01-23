using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.Infrastructure.EFPersistency.EF
{
    public class DbContextContainer
    {
        protected readonly PhotoDbContext _db;

        public DbContextContainer(PhotoDbContext db)
        {
            _db = db;
        }
    }
}
