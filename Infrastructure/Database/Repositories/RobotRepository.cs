using Domain;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Infrastructure.Database.Repositories;

public class RobotRepository : IRobotRepository
{
    private readonly ExplorationRobotsDbContext _dbContext;

    public RobotRepository(ExplorationRobotsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Robot>> GetAll()
        => await RobotContext().AsNoTracking().ToListAsync();

    public Task<Robot?> Get(int id)
        => RobotContext().FirstOrDefaultAsync(x => x.Id == id);

    public Task Create(Robot robot)
    {
        _dbContext.Robots.Attach(robot);
        return _dbContext.SaveChangesAsync();
    }

    public Task Update(Robot robot)
    {
        _dbContext.Robots.Attach(robot);
        return _dbContext.SaveChangesAsync();
    }

    private IIncludableQueryable<Robot, Area> RobotContext()
        => _dbContext.Robots.Include(x => x.Area);
}