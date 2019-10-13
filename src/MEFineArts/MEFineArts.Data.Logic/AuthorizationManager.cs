using MEFineArts.Data.Logic.Interfaces;
using MEFineArts.Data.Persistence.Interfaces;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace MEFineArts.Data.Logic
{
    public class AuthorizationManager : IAuthorizationManager
    {
        IRepository repository;
        ILogger<AuthorizationManager> logger;

        public AuthorizationManager(IRepository argRepository, ILogger<AuthorizationManager> argLogger)
        {
            repository = argRepository;
            logger = argLogger;
        }

        public async Task<bool> TryValidateAccessTokenAsync(string accessToken)
        {
            if (string.IsNullOrWhiteSpace(accessToken))
            {
                return false;
            }

            var isTokenValid = await repository.TryValidateAccessTokenAsync(accessToken);

            if (!isTokenValid)
            {
                logger.LogError($"The token provided was not valid : {accessToken}");
            }

            return isTokenValid;
        }
    }
}
