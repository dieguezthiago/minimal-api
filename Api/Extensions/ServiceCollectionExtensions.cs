using Domain;
using Domain.Services;
using Domain.Services.Implementation;
using Infrastructure.Database;
using Infrastructure.Database.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddMediatR(typeof(Program));
        services.AddAutoMapper(typeof(Program));
        return services;
    }

    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IPlanetService, PlanetService>();
        return services;
    }

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContext<ExplorationRobotsDbContext>(options => { options.UseInMemoryDatabase("inMemory"); });
        services.AddScoped<IPlanetRepository, PlanetRepository>();
        services.AddScoped<IRobotRepository, RobotRepository>();
        return services;
    }
}