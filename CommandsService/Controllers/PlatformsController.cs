using AutoMapper;
using CommandsService.Data;
using CommandsService.Dtos;

namespace CommandsService.Controllers
{

    using Microsoft.AspNetCore.Mvc;

    [Route("api/c/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly ICommandRepo _repository;
        private readonly IMapper _mapper;

        public PlatformsController(ICommandRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlatforms()
        {
            Console.WriteLine("--> Getting Platforms from ConmmmandService");

            var platformItems = _repository.getallPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));
        }
        
        [HttpPost]
        public async Task<IActionResult> TestInboundConnect()
        {
            Console.WriteLine("Write Connect");
            return Ok("This is CommandsService");
        }
    }
}