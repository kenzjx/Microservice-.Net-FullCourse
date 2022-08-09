using CommandsService.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandsService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
    {
      
    }
    
    public DbSet<Platform> Platforms { set; get; }
        
    public DbSet<Command> Commands { set; get; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .Entity<Platform>()
            .HasMany(p => p.Commands)
            .WithOne(p=> p.Platform!)
            .HasForeignKey(p => p.PlatformId);

        modelBuilder.Entity<Command>().HasOne(p => p.Platform).WithMany(p => p.Commands)
            .HasForeignKey(p => p.PlatformId);
    }
}