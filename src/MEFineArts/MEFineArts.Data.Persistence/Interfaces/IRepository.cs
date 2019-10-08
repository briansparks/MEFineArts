using MEFineArts.Data.Persistence.DataModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MEFineArts.Data.Persistence.Interfaces
{
    public interface IRepository
    {
        Task<string> GetUser(string userName, string password);
        Task<List<Content>> GetContent();
        Task<string> InsertOrUpdateContent(Content content);
        Task<int> InsertOrUpdateContent(List<Content> contentItems);
        Task<bool> TryValidateAccessToken(string accessToken);
    }
}
