using System.Threading.Tasks;

namespace MEFineArts.Data.Logic.Interfaces
{
    public interface IAuthorizationManager
    {
        Task<bool> TryValidateAccessTokenAsync(string accessToken);
    }
}
