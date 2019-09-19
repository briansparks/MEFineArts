using MEFineArts.Data.Persistence.Interfaces;
using System.Threading.Tasks;

namespace MEFineArts.Data.Persistence
{
    public class AuthorizationManager : IAuthorizationManager
    {
        IRepository repository;

        public AuthorizationManager(IRepository argRepository)
        {
            repository = argRepository;
        }

        public async Task<bool> TryValidateAccessToken(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
                return false;
            }

            return await repository.TryValidateAccessToken(accessToken);
        }
    }
}
