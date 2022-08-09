using System.ComponentModel.DataAnnotations;

namespace CommandsService.Models;

public class Platform
{
    [Key]
    [Required]
    public int Id { set; get; }

    [Required]
    public int ExternalID { set; get; }
    
    [Required]
    public string Name { set; get; }

    public ICollection<Command> Commands { set; get; } = new List<Command>();
}