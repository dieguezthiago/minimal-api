using Api.Models;
using AutoMapper;
using Domain;
using MediatR;

namespace Api.Queries;

public class GetAllPlanets : IRequest<IEnumerable<PlanetDto>>
{
}

public class GetAllPlanetsHandler : IRequestHandler<GetAllPlanets, IEnumerable<PlanetDto>>
{
    private readonly IPlanetRepository _planetRepository;
    private readonly IMapper _mapper;

    public GetAllPlanetsHandler(IPlanetRepository planetRepository, IMapper mapper)
    {
        _planetRepository = planetRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PlanetDto>> Handle(GetAllPlanets request, CancellationToken cancellationToken)
    {
        var planets = await _planetRepository.GetAll();
        return _mapper.Map<IEnumerable<PlanetDto>>(planets);
    }
}