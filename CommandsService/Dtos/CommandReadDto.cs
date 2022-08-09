namespace CommandsService.Dtos;

public class CommandReadDto
{
    public int Id { set; get; }

    public string HowTo { set; get; }
    
    public string CommandLine { get; set; }
    
    public int PlatformId { get; set; }
    
}