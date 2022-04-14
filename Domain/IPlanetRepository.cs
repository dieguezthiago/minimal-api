using Domain.Models;

namespace Domain;

public interface IPlanetRepository
{
    Task<IEnumerable<Planet>> GetAll();
    Task<Planet?> Get(int id);
    Task Create(Planet planet);
    Task Update(Planet planet);

}