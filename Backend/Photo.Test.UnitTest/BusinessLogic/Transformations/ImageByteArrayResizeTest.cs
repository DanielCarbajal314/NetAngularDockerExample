using Photo.BusinessLogic.Transformations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Photo.Test.UnitTest.BusinessLogic.Transformations
{
    public class ImageByteArrayResizeTest
    {
        [Fact]
        public void ShouldShrinkImage()
        {
            var shrinkJpgByteArray = ImageTestResources.ImAnotherJPG.BuiltThumbnailOfSize(300,300).Result;
            Assert.NotNull(shrinkJpgByteArray);
            Assert.True(shrinkJpgByteArray.Count() < ImageTestResources.ImAnotherJPG.Count());
            var fileType = shrinkJpgByteArray.GetImageType();
            Assert.Equal("jpg", fileType);
        }
    }
}
