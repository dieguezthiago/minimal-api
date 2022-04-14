using Domain;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Infrastructure.Database.Repositories;

public class PlanetRepository : IPlanetRepository
{
    private readonly ExplorationRobotsDbContext _dbContext;

    public PlanetRepository(ExplorationRobotsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Planet>> GetAll()
        => await PlanetsContext()
            .AsNoTracking()
            .ToListAsync();

    public Task<Planet?> Get(int id)
        => PlanetsContext().FirstOrDefaultAsync(x => x.Id == id);

    public Task Create(Planet planet)
    {
        _dbContext.Planets.Attach(planet);
        return _dbContext.SaveChangesAsync();
    }

    public Task Update(Planet planet)
    {
        _dbContext.Planets.Attach(planet);
        return _dbContext.SaveChangesAsync();
    }

    private IIncludableQueryable<Planet, ICollection<Robot>> PlanetsContext()
        => _dbContext
            .Planets
            .Include(x => x.Areas)
            .ThenInclude(x => x.Robots);
}