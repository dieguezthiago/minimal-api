using System.ComponentModel.DataAnnotations;
using Api.Models;
using AutoMapper;
using Domain;
using MediatR;

namespace Api.Queries;

public class GetPlanetById : IRequest<PlanetDto>
{
    public int Id { get; }

    public GetPlanetById(int id)
    {
        Id = id;
    }
}

public class GetPlanetByIdHandler : IRequestHandler<GetPlanetById, PlanetDto>
{
    private readonly IPlanetRepository _planetRepository;
    private readonly IMapper _mapper;

    public GetPlanetByIdHandler(IPlanetRepository planetRepository, IMapper mapper)
    {
        _planetRepository = planetRepository;
        _mapper = mapper;
    }

    public async Task<PlanetDto> Handle(GetPlanetById request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            throw new ValidationException("Id is not valid!");

        var planet = await _planetRepository.Get(request.Id);

        return _mapper.Map<PlanetDto>(planet);
    }
}