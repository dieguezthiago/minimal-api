using Api.Models;
using AutoMapper;
using Domain;
using MediatR;

namespace Api.Queries;

public class GetAllRobots : IRequest<IEnumerable<RobotDto>>
{
}

public class GetAllRobotsHandler : IRequestHandler<GetAllRobots, IEnumerable<RobotDto>>
{
    private readonly IRobotRepository _robotRepository;
    private readonly IMapper _mapper;

    public GetAllRobotsHandler(IRobotRepository robotRepository, IMapper mapper)
    {
        _robotRepository = robotRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RobotDto>> Handle(GetAllRobots request, CancellationToken cancellationToken)
    {
        var robots = await _robotRepository.GetAll();
        return _mapper.Map<IEnumerable<RobotDto>>(robots);
    }
}