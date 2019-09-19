using MEFineArts.Data.Persistence.DataModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MEFineArts.Data.Persistence.Interfaces
{
    public interface IRepository
    {
        Task<Guid?> GetUser(string userName, string password);
        Task<List<Content>> GetContent();
        Task<string> InsertOrUpdateContent(Content content);
        Task<bool> TryValidateAccessToken(string accessToken);
    }
}
