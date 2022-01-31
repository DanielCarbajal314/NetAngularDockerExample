using Photo.Domain.External.File.Common;
using Photo.Infrastructure.AWS;
using Photo.Test.UnitTest.BusinessLogic;
using Photo.Test.UnitTest.Infrastructure.AWS.Boostrap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Photo.Test.UnitTest.Infrastructure.AWS
{
    public class AmazonS3ClientTest
    {


        [Fact]
        public void ShouldConnectToS3()
        {
            var client = new S3FileRepository(new TestAwsSettings());
            var result = client.SaveFile(new ImageToSaveRequest
            {
                FileName = "test.png",
                Data = ImageTestResources.ImAnotherPNG
            }).Result;
            Assert.Contains("localhost", result.URL);
        }
    }
}
