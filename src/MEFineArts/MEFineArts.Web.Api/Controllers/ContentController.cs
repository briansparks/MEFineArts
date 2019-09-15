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
        private IDataManager _dataManager;

        public ContentController(IDataManager argDataManager)
        {
            _dataManager = argDataManager;
        }

        [EnableCors("CorsPolicy")]
        [HttpGet]
        public async Task<ActionResult<List<Content>>> GetContent()
        {
            return await _dataManager.GetContent();
        }
    }
}
