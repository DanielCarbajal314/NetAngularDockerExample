using Photo.BusinessLogic.Transformations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Photo.Test.UnitTest.BusinessLogic.Transformations
{
    public  class ByteArrayImageTypeTest
    {
        [Fact]
        public void ShouldIdentifyPNG()
        {
            var fileType = ImageTestResources.ImPNG.GetImageType();
            Assert.Equal("png", fileType);
            var secondFileType = ImageTestResources.ImAnotherPNG.GetImageType();
            Assert.Equal("png", fileType);
        }

        [Fact]
        public void ShouldIdentifyJPG()
        {
            var fileType = ImageTestResources.ImJPG.GetImageType();
            Assert.Equal("jpg", fileType);
            var secondFileType = ImageTestResources.ImAnotherJPG.GetImageType();
            Assert.Equal("jpg", fileType);
        }

        [Fact]
        public void ShouldIdentifyNotAllowedFormat()
        {
            var fileType = ImageTestResources.ImNotAnImage.GetImageType();
            Assert.Null(fileType);
        }
    }
}
