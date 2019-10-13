using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MEFineArts.Data.Logic.Interfaces
{
    public interface IImageManager
    {
        Task<bool> TryUploadImageAsync(IFormFile file);
    }
}
