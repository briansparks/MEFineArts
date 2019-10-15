using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using MEFineArts.Data.Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MEFineArts.Data.Logic
{
    public class ImageManager : IImageManager
    {
        private ILogger<ImageManager> logger;

        private const string bucketName = "mefinearts";
        private const string bucketPath = "Content/Images/Gallery/";

        private static IAmazonS3 s3Client;

        RegionEndpoint bucketRegion = RegionEndpoint.USEast1;

        public ImageManager(string s3KeyId, string s3Key, ILogger<ImageManager> argLogger)
        {
            logger = argLogger;
            s3Client = new AmazonS3Client(s3KeyId, s3Key, bucketRegion);
        }

        public async Task<bool> TryUploadImageAsync(IFormFile file)
        {
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    file.CopyTo(memoryStream);

                    var request = new TransferUtilityUploadRequest
                    {
                        InputStream = memoryStream,
                        Key = bucketPath + file.FileName,
                        BucketName = bucketName,
                        CannedACL = S3CannedACL.PublicRead
                    };

                    var fileTransferUtility = new TransferUtility(s3Client);
                    await fileTransferUtility.UploadAsync(request);
                }

                return true;
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to upload image : {ex}");
            }

            return false;
        }
    }
}
