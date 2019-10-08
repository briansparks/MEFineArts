using MEFineArts.Data.Persistence.DataModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MEFineArts.Data.Logic.Interfaces
{
    public interface IDataManager
    {
        Task<string> GetUser(string userName, string password);
        Task<List<Content>> GetContent();
        Task<string> InsertOrUpdateContent(string title, string page, string contentType, string value);
        Task<int> InsertOrUpdateContent(List<Content> contentItems);
    }
}
