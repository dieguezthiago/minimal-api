using System.ComponentModel.DataAnnotations;
using Api.Models;
using AutoMapper;
using Domain;
using MediatR;

namespace Api.Commands;

public class AssignRobotToPlanet : IRequest<PlanetDto>
{
    public int PlanetId { get; }
    public int AreaId { get; }
    public int RobotId { get; }

    public AssignRobotToPlanet(int planetId, int areaId, int robotId)
    {
        PlanetId = planetId;
        AreaId = areaId;
        RobotId = robotId;
    }
}

public class AssignRobotToPlanetHandler : IRequestHandler<AssignRobotToPlanet, PlanetDto>
{
    private readonly IPlanetRepository _planetRepository;
    private readonly IRobotRepository _robotRepository;
    private readonly IMapper _mapper;

    public AssignRobotToPlanetHandler(IPlanetRepository planetRepository, IRobotRepository robotRepository, IMapper mapper)
    {
        _planetRepository = planetRepository;
        _robotRepository = robotRepository;
        _mapper = mapper;
    }

    public async Task<PlanetDto> Handle(AssignRobotToPlanet request, CancellationToken cancellationToken)
    {
        var getPlanetTask = _planetRepository.Get(request.PlanetId);
        var getRobotTask = _robotRepository.Get(request.RobotId);

        await Task.WhenAll(getPlanetTask, getRobotTask);

        var planet = getPlanetTask.Result ?? throw new ValidationException("Planet not found!"); //TODO: should represent a NotFound error to be picked by the middleware
        var robot = getRobotTask.Result ?? throw new ValidationException("Robot not found!"); //TODO: should represent a NotFound error to be picked by the middleware

        planet.AssignRobotToArea(request.AreaId, robot);
        await _planetRepository.Update(planet);
        return _mapper.Map<PlanetDto>(planet);
    }
}