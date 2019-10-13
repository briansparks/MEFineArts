using MEFineArts.Data.Logic.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MEFineArts.Web.Api.Controllers
{
    [EnableCors("CorsPolicy")]
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
        public async Task<ActionResult<string>> GetUserAsync(string username, string password)
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
