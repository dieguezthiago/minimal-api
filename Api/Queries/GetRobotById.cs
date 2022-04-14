using System.ComponentModel.DataAnnotations;
using Api.Models;
using AutoMapper;
using Domain;
using MediatR;

namespace Api.Queries;

public class GetRobotById : IRequest<RobotDto>
{
    public int Id { get; }

    public GetRobotById(int id)
    {
        Id = id;
    }
}

public class GetRobotByIdHandler : IRequestHandler<GetRobotById, RobotDto>
{
    private readonly IRobotRepository _robotRepository;
    private readonly IMapper _mapper;

    public GetRobotByIdHandler(IRobotRepository robotRepository, IMapper mapper)
    {
        _robotRepository = robotRepository;
        _mapper = mapper;
    }

    public async Task<RobotDto> Handle(GetRobotById request, CancellationToken cancellationToken)
    {
        if (request.Id <= 0)
            throw new ValidationException("Id is not valid!");

        var robot = await _robotRepository.Get(request.Id);

        return _mapper.Map<RobotDto>(robot);
    }
}