namespace CommandsService.Controllers
{

    using Microsoft.AspNetCore.Mvc;

    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok();
        }
    }
}