using MEFineArts.Data.Logic.Interfaces;
using MEFineArts.Data.Persistence.DataModels;
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

        private readonly string accessTokenHeader;

        public ContentController(IDataManager argDataManager, IAuthorizationManager argAuthorizationManager)
        {
            accessTokenHeader = "X-Authorization-Access-Token";

            dataManager = argDataManager;
            authorizationManager = argAuthorizationManager;
        }

        [EnableCors("CorsPolicy")]
        [HttpGet]
        public async Task<ActionResult<List<Content>>> GetContent()
        {
            return await dataManager.GetContent();
        }

        [EnableCors("CorsPolicy")]
        [HttpPut("{contentId}")]
        public async Task<ActionResult> InsertOrUpdateContent(string title, string page, string contentType, string value)
        {
            Request.Headers.TryGetValue(accessTokenHeader, out var accessToken);

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

        [EnableCors("CorsPolicy")]
        [HttpPut]
        public async Task<ActionResult> InsertOrUpdateContentList([FromBody] List<Content> contentItems)
        {
            Request.Headers.TryGetValue(accessTokenHeader, out var accessToken);

            if (!await authorizationManager.TryValidateAccessToken(accessToken))
            {
                return Unauthorized();
            }
            else
            {
                var result = await dataManager.InsertOrUpdateContent(contentItems);
            }

            return Ok();
        }
    }
}
