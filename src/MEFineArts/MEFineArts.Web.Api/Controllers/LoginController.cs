using MEFineArts.Data.Persistence.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MEFineArts.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IDataManager dataManager;

        public LoginController(IDataManager argDataManager)
        {
            dataManager = argDataManager;
        }

        [HttpGet("user")]
        public async Task<ActionResult<Guid>> GetUserAsync(string username, string password)
        {

            var accessToken = await dataManager.GetUser(username, password);

            if (accessToken == null)
            {
                return new NotFoundResult();
            }
     
            return new OkObjectResult(accessToken);
        }
    }
}
