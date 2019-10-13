using MEFineArts.Data.Logic.Interfaces;
using MEFineArts.Data.Persistence.DataModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
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
        private IImageManager imageManager;
        private IAuthorizationManager authorizationManager;

        private readonly string accessTokenHeader;

        public ContentController(IDataManager argDataManager, IAuthorizationManager argAuthorizationManager, IImageManager argImageManager)
        {
            accessTokenHeader = "X-Authorization-Access-Token";

            dataManager = argDataManager;
            imageManager = argImageManager;
            authorizationManager = argAuthorizationManager;
        }

        [EnableCors("CorsPolicy")]
        [HttpGet]
        public async Task<ActionResult<List<Content>>> GetContentAsync()
        {
            return await dataManager.GetContentAsync();
        }

        [EnableCors("CorsPolicy")]
        [HttpPut("{contentId}")]
        public async Task<ActionResult> InsertOrUpdateContentAsync(string title, string page, string contentType, string value)
        {
            Request.Headers.TryGetValue(accessTokenHeader, out var accessToken);

            if (!await authorizationManager.TryValidateAccessTokenAsync(accessToken))
            {
                return Unauthorized();
            }
            else
            {
                var result = await dataManager.InsertOrUpdateContentAsync(title, page, contentType, value);
            }

            return Ok();
        }

        [EnableCors("CorsPolicy")]
        [HttpPut]
        public async Task<ActionResult> InsertOrUpdateContentAsyncList([FromBody] List<Content> contentItems)
        {
            Request.Headers.TryGetValue(accessTokenHeader, out var accessToken);

            if (!await authorizationManager.TryValidateAccessTokenAsync(accessToken))
            {
                return Unauthorized();
            }
            else
            {
                var result = await dataManager.InsertOrUpdateContentAsync(contentItems);
            }

            return Ok();
        }

        [EnableCors("CorsPolicy")]
        [HttpPut("image")]
        public async Task<ActionResult> UploadImageAsync([FromForm(Name = "file")] IFormFile file)
        {
            var imageUrl = string.Empty;
            Request.Headers.TryGetValue(accessTokenHeader, out var accessToken);

            if (!await authorizationManager.TryValidateAccessTokenAsync(accessToken))
            {
                return Unauthorized();
            }
            else
            {
                var result = await imageManager.TryUploadImageAsync(file);

                if (result)
                {
                    imageUrl = await dataManager.InsertGalleryImage(file);
                }
                else
                {
                    return BadRequest();
                }
            }

            return Ok(imageUrl);
        }

        [EnableCors("CorsPolicy")]
        [HttpDelete("{contentId}")]
        public async Task<ActionResult> DeleteContentAsync(string contentId)
        {
            Request.Headers.TryGetValue(accessTokenHeader, out var accessToken);

            if (!await authorizationManager.TryValidateAccessTokenAsync(accessToken))
            {
                return Unauthorized();
            }
            else
            {
                var result = await dataManager.DeleteContentAsync(contentId);

                if (!result)
                {
                    return BadRequest();
                }
            }

            return Ok();
        }
    }
}
