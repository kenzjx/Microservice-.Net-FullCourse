using System.ComponentModel.DataAnnotations;

namespace CommandsService.Models;

public class Command
{
    [Key] [Required] public int Id { set; get; }

    [Required] public string HowTo { set; get; }
    [Required] public string CommandLine { get; set; }
    [Required] public int PlatformId { get; set; }
    [Required] public Platform Platform { set; get; }
}