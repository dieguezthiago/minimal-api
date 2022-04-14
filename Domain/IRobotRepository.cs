using Domain.Models;

namespace Domain;

public interface IRobotRepository
{
    Task<IEnumerable<Robot>> GetAll();
    Task<Robot?> Get(int id);
    Task Create(Robot robot);
    Task Update(Robot robot);
}