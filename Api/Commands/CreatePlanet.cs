using System.ComponentModel.DataAnnotations;
using Api.Models;
using AutoMapper;
using Domain;
using Domain.Models;
using Domain.Services;
using MediatR;

namespace Api.Commands;

public class CreatePlanet : IRequest<PlanetDto>
{
    public string Name { get; }

    public CreatePlanet(string name)
    {
        Name = name;
    }
}

public class CreatePlanetHandler : IRequestHandler<CreatePlanet, PlanetDto>
{
    private readonly IPlanetService _planetService;
    private readonly IMapper _mapper;

    public CreatePlanetHandler(IPlanetService planetService, IMapper mapper)
    {
        _planetService = planetService;
        _mapper = mapper;
    }

    public async Task<PlanetDto> Handle(CreatePlanet request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            throw new ValidationException("A valid name should be provided!");

        return _mapper.Map<PlanetDto>(await _planetService.Create(request.Name));
    }
}