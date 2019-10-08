using System.Threading.Tasks;

namespace MEFineArts.Data.Logic.Interfaces
{
    public interface IAuthorizationManager
    {
        Task<bool> TryValidateAccessToken(string accessToken);
    }
}
