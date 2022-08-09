using CommandsService.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandsService.Data;

public class CommandRepo : ICommandRepo
{
    private readonly AppDbContext _context;

    public CommandRepo(AppDbContext context)
    {
        _context = context;
    }
    
    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }

    public IEnumerable<Platform> getallPlatforms()
    {
        return _context.Platforms.ToList();
    }

    public void CreatePlatform(Platform plat)
    {
        if (plat == null)
        {
            throw new ArgumentException(nameof(plat));
        }

        _context.Entry<Platform>(plat).State = EntityState.Added;
    }

    public bool PlatformExits(int PlatformId)
    {
        return _context.Platforms.Any(p => p.Id == PlatformId);
    }

    public IEnumerable<Command> getCommandsForPlatform(int platformId)
    {
        return _context.Commands.Where(c => c.PlatformId == platformId).OrderBy(c => c.Platform.Name);
    }

    public Command getCommand(int platformId, int commandId)
    {
        return _context.Commands.Where(c => c.PlatformId == platformId && c.Id == commandId).FirstOrDefault();
    }

    public void CreateCommand(int platformId, Command command)
    {
        if (command == null)
        {
            throw new ArgumentException(nameof(command));
        }

        command.PlatformId = platformId;
        _context.Entry<Command>(command).State = EntityState.Added;
    }
}