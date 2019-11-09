using Microsoft.AspNetCore.Mvc;

namespace MEFineArts.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeartbeatController : ControllerBase
    {
        [HttpGet]
        public string Heartbeat()
        {
            return "I'm alive!";
        }
    }
}
