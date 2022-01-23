using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System.IO;
using System.Threading.Tasks;

namespace Photo.BusinessLogic.Transformations
{
    public static class ImageByteArrayResize
    {
        public static async Task<byte[]> BuiltThumbnailOfSize(this byte[] data, int width, int height)
        {
            using (var readMemoryStream = new MemoryStream(data))
            {
                using (var writeMemoryStrem = new MemoryStream())
                {
                    var image = await Image.LoadAsync(readMemoryStream);
                    image.Mutate(x => x.Resize(width, height));
                    await image.SaveAsJpegAsync(writeMemoryStrem);
                    return writeMemoryStrem.ToArray();
                }
            }
        }
    }
}
