using Photo.Infrastructure.AWS.Bootstrap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo.Test.UnitTest.Infrastructure.AWS.Boostrap
{
    internal class TestAwsSettings : IAwsSettings
    {
        public string Key => "foobar";

        public string Secret => "foobar";

        public string BucketName => "public-bucket";

        public string AWSRegion => "us-east-1";

        public string? AwsUrl => @"http://localhost:4566";
    }
}
