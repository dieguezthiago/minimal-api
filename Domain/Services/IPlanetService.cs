using Domain.Models;

namespace Domain.Services;

public interface IPlanetService
{
    Task<Planet> Create(string name);
}