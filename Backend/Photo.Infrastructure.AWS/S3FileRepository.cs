using Amazon.S3;
using Amazon.S3.Model;
using Photo.Domain.External.File;
using Photo.Domain.External.File.Common;
using Photo.Infrastructure.AWS.Bootstrap;

namespace Photo.Infrastructure.AWS
{
    public class S3FileRepository : IFileRepository
    {
        private readonly IAwsSettings _AWSSettings;

        public S3FileRepository(IAwsSettings AWSSettings)
        {
            this._AWSSettings = AWSSettings;
        }

        public async Task<byte[]> GetFileByName(string fileName)
        {
            using (var s3Client = this.buildS3Config())
            {
                using (var ms = new MemoryStream())
                {
                    var response = await s3Client.GetObjectAsync(this._AWSSettings.BucketName, fileName);
                    response.ResponseStream.CopyTo(ms);
                    return ms.ToArray();
                }
            }
        }

        public async Task<ImageToSaveResponse> SaveFile(ImageToSaveRequest request)
        {
            using (var s3Client = this.buildS3Config())
            {
                using(var inputStream = new MemoryStream(request.Data)) 
                {
                    await s3Client.PutObjectAsync(new PutObjectRequest
                    {
                        BucketName = this._AWSSettings.BucketName,
                        Key = request.FileName,
                        InputStream = inputStream,
                        CannedACL = S3CannedACL.PublicRead
                    });
                }
            }
            return new ImageToSaveResponse
            {
                URL = buildFileUrl(request.FileName)
            };
        }

        private AmazonS3Client buildS3Config()
        {
            var config = new AmazonS3Config();
            if (this._AWSSettings.AwsUrl != null)
            {
                config.ServiceURL = this._AWSSettings.AwsUrl;
                config.ForcePathStyle = true;
            }
            return new AmazonS3Client(this._AWSSettings.Key, this._AWSSettings.Secret, config);
        }

        private string buildFileUrl(string fileName)
        {
            return this._AWSSettings.AwsUrl != null ? 
                $"{this._AWSSettings.AwsUrl}/{this._AWSSettings.BucketName}/{fileName}" : 
                $"https://${this._AWSSettings.BucketName}.s3.${this._AWSSettings.AWSRegion}.amazonaws.com/${fileName}";
        }

    }
}