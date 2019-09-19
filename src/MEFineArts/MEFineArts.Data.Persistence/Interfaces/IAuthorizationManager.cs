using System.Threading.Tasks;

namespace MEFineArts.Data.Persistence.Interfaces
{
    public interface IAuthorizationManager
    {
        Task<bool> TryValidateAccessToken(string accessToken);
    }
}
