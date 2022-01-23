using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Photo.Infrastructure.EFPersistency.Bootstrap;
using Photo.Infrastructure.EFPersistency.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.Infrastructure.EFPersistency
{
    public class PhotoContextFactory : IDesignTimeDbContextFactory<PhotoDbContext>
    {
        public PhotoDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PhotoDbContext>();
            var configuration = new MigrationSettings();
            var connectionString = 
            $@"
                data source={configuration.Host},{configuration.Port};
                initial catalog={configuration.Catalog};
                user id={configuration.Username};
                password={configuration.Password};
            ";
            optionsBuilder.UseSqlServer(connectionString);
            return new PhotoDbContext(optionsBuilder.Options);
        }

        private class MigrationSettings : ISqlEnviromentSettings
        {
            public string Host => "localhost";
            public string Port => "1435";
            public string Catalog => "photoAlbums";
            public string Username => "sa";
            public string Password => "M!cr0soft";
        }
    }
}
