using Photo.BusinessLogic.Transformations;
using Xunit;

namespace Photo.Test.UnitTest.BusinessLogic.Transformations
{
    public class ByteArrayMD5SignatureTest
    {
        [Fact]
        public void SignaturesOfEqualFilesShouldMatch()
        {
            var signatureOne = ImageTestResources.ImAnotherJPG.CalculateMD5Signature();
            var signatureTwo = ImageTestResources.CopyOfImAnotherJPG.CalculateMD5Signature();
            Assert.Equal(signatureOne, signatureTwo);
        }

        [Fact]
        public void SignaturesOfEqualFilesShouldNotMatch()
        {
            var signatureOne = ImageTestResources.ImAnotherJPG.CalculateMD5Signature();
            var signatureTwo = ImageTestResources.ImAnotherPNG.CalculateMD5Signature();
            Assert.NotEqual(signatureOne, signatureTwo);
        }
    }
}
