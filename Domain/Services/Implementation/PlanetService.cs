using System.Numerics;
using Domain.Models;

namespace Domain.Services.Implementation;

public class PlanetService : IPlanetService
{
    private readonly IPlanetRepository _planetRepository;

    public PlanetService(IPlanetRepository planetRepository)
    {
        _planetRepository = planetRepository;
    }

    public async Task<Planet> Create(string name)
    {
        var planet = new Planet(name);
        planet.AddArea(5, 5);
        planet.AddArea(5, 5);
        planet.AddArea(5, 5);

        await _planetRepository.Create(planet);

        return planet;
    }
}