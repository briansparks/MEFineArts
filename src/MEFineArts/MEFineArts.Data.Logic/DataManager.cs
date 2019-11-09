using MEFineArts.Data.Logic.Interfaces;
using MEFineArts.Data.Persistence.DataModels;
using MEFineArts.Data.Persistence.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static MEFineArts.Data.Persistence.Enums.DataEnums;

namespace MEFineArts.Data.Persistence
{
    public class DataManager : IDataManager
    {
        private IRepository repository;
        private ILogger<DataManager> logger;

        private const string publicImageUrlPrefix = "https://mefinearts.s3.amazonaws.com/Content/Images/Gallery/";

        public DataManager(IRepository argRepository, ILogger<DataManager> argLogger)
        {
            repository = argRepository;
            logger = argLogger;
        }

        public async Task<string> GetUserAsync(string userName, string password)
        {
            try
            {
                return await repository.GetUserAsync(userName, password);
            } 
            catch (Exception ex)
            {
                logger.LogDebug($"Failed to retrieve credentials for user {userName} : {ex}");
            }

            return null;
        }

        public async Task<List<Content>> GetContentAsync()
        {
            try
            {
                return await repository.GetContentAsync();
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to retrieve content : {ex}");
            }

            return null;
        }

        public async Task<string> InsertOrUpdateContentAsync(string title, string page, string contentType, string value)
        {
            try
            {
                var content = new Content() { ContentId = GenerateContentId(page, title), Page = page, Value = value, ContentType = contentType };
                return await repository.InsertOrUpdateContentAsync(content);
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to upsert content : {ex}");
            }

            return null;
        }

        public async Task<int> InsertOrUpdateContentAsync(List<Content> contentItems)
        {
            try
            {
                return await repository.InsertOrUpdateContentAsync(contentItems);
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to upsert content : {ex}");
            }

            return 0;
        }

        public async Task<string> InsertGalleryImage(IFormFile image)
        {
            try
            {
                var imageUrl = publicImageUrlPrefix + image.FileName;

                var content = new Content()
                {
                    ContentId = GenerateContentId("gallery", Guid.NewGuid().ToString()),
                    InsertDate = DateTime.Now,
                    Page = "Gallery",
                    Value = imageUrl,
                    ContentType = ContentType.Image.ToString()
                };

                await repository.InsertOrUpdateContentAsync(content);
                return imageUrl;
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to insert gallery image to repository : {ex}");
            }

            return null;
        }

        public async Task<bool> DeleteContentAsync(string contentId)
        {
            try
            {
                await repository.DeleteContentAsync(contentId);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to delete content with id {contentId} : {ex}");
            }

            return false;
        }

        private string GenerateContentId(string page, string title)
        {
            return $"{page}-{title}";
        }
    }
}
