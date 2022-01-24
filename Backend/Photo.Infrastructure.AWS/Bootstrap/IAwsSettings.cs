using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.Infrastructure.AWS.Bootstrap
{
    public interface IAwsSettings
    {
        public string Key { get; }
        public string Secret { get; }
        public string BucketName { get; }
        public string AWSRegion { get; }
        public string? AwsUrl { get; }
    }
}
