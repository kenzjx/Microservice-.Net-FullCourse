using CommandsService.Models;

namespace CommandsService.Data;

public interface ICommandRepo
{
    bool SaveChanges();

    IEnumerable<Platform> getallPlatforms();

    void CreatePlatform(Platform plat);
    bool PlatformExits(int PlatformId);
    
    // Commands

    IEnumerable<Command> getCommandsForPlatform(int platformId);
    Command getCommand(int platformId, int commandId);

    void CreateCommand(int platformId, Command command);
}