namespace CommandsService.Controllers
{

    using Microsoft.AspNetCore.Mvc;

    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> TestInboundConnect()
        {
            Console.WriteLine("Write Connect");
            return Ok("This is CommandsService");
        }
    }
}