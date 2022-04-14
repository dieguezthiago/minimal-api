using System.ComponentModel.DataAnnotations;
using Api.Models;
using AutoMapper;
using Domain;
using Domain.Models;
using MediatR;

namespace Api.Commands;

public class CreateRobot : IRequest<RobotDto>
{
    public string Name { get; }

    public CreateRobot(string name)
    {
        Name = name;
    }
}

public class CreateRobotHandler : IRequestHandler<CreateRobot, RobotDto>
{
    private readonly IRobotRepository _robotRepository;
    private readonly IMapper _mapper;

    public CreateRobotHandler(IRobotRepository robotRepository, IMapper mapper)
    {
        _robotRepository = robotRepository;
        _mapper = mapper;
    }

    public async Task<RobotDto> Handle(CreateRobot request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            throw new ValidationException("A valid name should be provided!");

        var newRobot = new Robot(request.Name);
        await _robotRepository.Create(newRobot);
        return _mapper.Map<RobotDto>(newRobot);
    }
}