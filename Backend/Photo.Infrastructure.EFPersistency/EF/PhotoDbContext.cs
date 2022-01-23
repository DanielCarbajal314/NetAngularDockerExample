using Microsoft.EntityFrameworkCore;
using Photo.Domain.Entities;

namespace Photo.Infrastructure.EFPersistency.EF
{
    public class PhotoDbContext: DbContext
    {
        public DbSet<PhotoImage> PhotoImages { get; set; }

        #pragma warning disable CS8618 // EF is in charge of inititalize DbSet Properties
        public PhotoDbContext(DbContextOptions options) : base(options)
        #pragma warning restore CS8618
        {

        }
    }
}
