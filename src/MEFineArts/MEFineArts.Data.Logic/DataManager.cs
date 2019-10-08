using MEFineArts.Data.Logic.Interfaces;
using MEFineArts.Data.Persistence.DataModels;
using MEFineArts.Data.Persistence.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MEFineArts.Data.Persistence
{
    public class DataManager : IDataManager
    {
        private IRepository repository;
        private ILogger<DataManager> logger;

        public DataManager(IRepository argRepository, ILogger<DataManager> argLogger)
        {
            repository = argRepository;
            logger = argLogger;
        }

        public async Task<string> GetUser(string userName, string password)
        {
            try
            {
                return await repository.GetUser(userName, password);
            } 
            catch (Exception ex)
            {
                logger.LogDebug($"Failed to retrieve credentials for user {userName} : {ex.StackTrace}");
            }

            return null;
        }

        public async Task<List<Content>> GetContent()
        {
            try
            {
                return await repository.GetContent();
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to retrieve content : {ex.StackTrace}");
            }

            return null;
        }

        public async Task<string> InsertOrUpdateContent(string title, string page, string contentType, string value)
        {
            try
            {
                var content = new Content() { ContentId = GenerateContentId(page, title), Page = page, Value = value, ContentType = contentType };
                return await repository.InsertOrUpdateContent(content);
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to upsert content : {ex.StackTrace}");
            }

            return null;
        }

        public async Task<int> InsertOrUpdateContent(List<Content> contentItems)
        {
            try
            {
                return await repository.InsertOrUpdateContent(contentItems);
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to upsert content : {ex.StackTrace}");
            }

            return 0;
        }

        private string GenerateContentId(string page, string title)
        {
            return $"{page}-{title}";
        }
    }
}
