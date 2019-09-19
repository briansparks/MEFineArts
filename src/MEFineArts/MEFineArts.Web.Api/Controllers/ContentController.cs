using MEFineArts.Data.Persistence.DataModels;
using MEFineArts.Data.Persistence.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MEFineArts.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private IDataManager dataManager;
        private IAuthorizationManager authorizationManager;

        public ContentController(IDataManager argDataManager, IAuthorizationManager argAuthorizationManager)
        {
            dataManager = argDataManager;
            authorizationManager = argAuthorizationManager;
        }

        [EnableCors("CorsPolicy")]
        [HttpGet]
        public async Task<ActionResult<List<Content>>> GetContent()
        {
            return await dataManager.GetContent();
        }

        [HttpPut]
        public async Task<ActionResult> InsertOrUpdateContent(string title, string page, string contentType, string value)
        {
            //TODO: Check for the access token in the header, if they have it, let them do the upsert.  If they don't, return unauthorized;
            Request.Headers.TryGetValue("accessToken", out var accessToken);

            if (!await authorizationManager.TryValidateAccessToken(accessToken))
            {
                return Unauthorized();
            }
            else
            {
                var result = await dataManager.InsertOrUpdateContent(title, page, contentType, value);
            }

            return Ok();
        }
    }
}
