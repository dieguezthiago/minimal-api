using System.ComponentModel.DataAnnotations;
using Api.Models;
using AutoMapper;
using Domain;
using MediatR;

namespace Api.Commands;

public class RobotTurnLeft : IRequest<RobotDto>
{
    public int RobotId { get; }

    public RobotTurnLeft(int robotId)
    {
        RobotId = robotId;
    }
}

public class RobotTurnLeftHandler : IRequestHandler<RobotTurnLeft, RobotDto>
{
    private readonly IRobotRepository _robotRepository;
    private readonly IMapper _mapper;

    public RobotTurnLeftHandler(IRobotRepository robotRepository, IMapper mapper)
    {
        _robotRepository = robotRepository;
        _mapper = mapper;
    }

    public async Task<RobotDto> Handle(RobotTurnLeft request, CancellationToken cancellationToken)
    {
        var robot = await _robotRepository.Get(request.RobotId) ?? throw new ValidationException("Robot not found!"); //TODO: should represent a NotFound error to be picked by the middleware

        robot.TurnLeft();

        await _robotRepository.Update(robot);

        return _mapper.Map<RobotDto>(robot);
    }
}