using AutoMapper;
using CommandsService.Data;
using CommandsService.Dtos;
using CommandsService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers;

[ApiController]
[Route("api/c/platforms/{platformId}/[controller]")]
public class CommandsController : ControllerBase
{
    private readonly ICommandRepo _repository;
    private readonly IMapper _mapper;

    public CommandsController(ICommandRepo repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetCommandsForPlatform(int platformId)
    {
        Console.WriteLine($"---> Hit GetCommandsfromPlatform: {platformId}");
        
        if(!_repository.PlatformExits(platformId))
        {
            return NotFound();
        }

        var commands = _repository.getCommandsForPlatform(platformId);

        return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
        
    }

    [HttpGet("{commandId}", Name = "GetCommandForPlatform")]
    public async Task<IActionResult> GetCommandForPlatform(int platformId, int commandId)
    {
        Console.WriteLine($"---> Hit GetCommandsfromPlatform: {platformId} / {commandId}");
        
        if(!_repository.PlatformExits(platformId))
        {
            return NotFound();
        }

        var command = _repository.getCommand(platformId, commandId);

        if (command == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<CommandReadDto>(command));
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCommandForPlatform(int platformId, CommandCreateDto commandCreateDto)
    {
        Console.WriteLine($"---> Hit GetCommandsfromPlatform: {platformId}");
        
        if(!_repository.PlatformExits(platformId))
        {
            return NotFound();
        }

        var command = _mapper.Map<Command>(commandCreateDto);
        
        _repository.CreateCommand(platformId, command);
        
        _repository.SaveChanges();

        var commandReadDto = _mapper.Map<CommandReadDto>(command);

        return CreatedAtRoute(nameof(GetCommandForPlatform),
            new { platformId = platformId, commandId = commandReadDto.Id }, commandReadDto);
        
    }
}