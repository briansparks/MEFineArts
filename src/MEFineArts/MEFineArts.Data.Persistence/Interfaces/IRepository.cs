using MEFineArts.Data.Persistence.DataModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MEFineArts.Data.Persistence.Interfaces
{
    public interface IRepository
    {
        Task<string> GetUserAsync(string userName, string password);
        Task<List<Content>> GetContentAsync();
        Task<string> InsertOrUpdateContentAsync(Content content);
        Task<int> InsertOrUpdateContentAsync(List<Content> contentItems);
        Task<bool> TryValidateAccessTokenAsync(string accessToken);
        Task DeleteContentAsync(string contentId);
    }
}
