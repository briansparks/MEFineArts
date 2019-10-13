using MEFineArts.Data.Persistence.DataModels;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MEFineArts.Data.Logic.Interfaces
{
    public interface IDataManager
    {
        Task<string> GetUserAsync(string userName, string password);
        Task<List<Content>> GetContentAsync();
        Task<string> InsertOrUpdateContentAsync(string title, string page, string contentType, string value);
        Task<int> InsertOrUpdateContentAsync(List<Content> contentItems);
        Task<string> InsertGalleryImage(IFormFile image);
        Task<bool> DeleteContentAsync(string contentId);
    }
}
