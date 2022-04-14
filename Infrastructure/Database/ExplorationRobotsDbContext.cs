using Domain.Models;
using Infrastructure.Database.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database;

public class ExplorationRobotsDbContext : DbContext
{
    public DbSet<Planet> Planets { get; set; }
    
    public DbSet<Area> Areas { get; set; }
    public DbSet<Robot> Robots { get; set; }

    public ExplorationRobotsDbContext(DbContextOptions<ExplorationRobotsDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PlanetConfiguration());
        modelBuilder.ApplyConfiguration(new AreaConfiguration());
        modelBuilder.ApplyConfiguration(new RobotConfiguration());
    }
}