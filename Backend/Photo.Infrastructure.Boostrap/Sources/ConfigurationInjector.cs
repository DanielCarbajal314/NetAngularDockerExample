using Microsoft.Extensions.Configuration;
using Photo.Infrastructure.Boostrap.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.Infrastructure.Boostrap.Sources
{
    public class ConfigurationInjector : IPhotoSettings
    {
        private readonly IConfiguration _configuration;

        public ConfigurationInjector(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Host => _configuration["DATABASE_HOST"];

        public string Port => _configuration["DATABASE_PORT"];

        public string Catalog => _configuration["DATABASE_CATALOG"];

        public string Username => _configuration["DATABASE_USERNAME"];

        public string Password => _configuration["DATABASE_PASSWORD"];

        public string Key => _configuration["AWS_KEY"];

        public string Secret => _configuration["AWS_SECRET"];

        public string BucketName => _configuration["AWS_BUCKETNAME"];

        public string AWSRegion => _configuration["AWS_REGION"];

        public string? AwsUrl => _configuration["AWS_URL"];
    }
}
