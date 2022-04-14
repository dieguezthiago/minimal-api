using AutoMapper;
using Domain.Models;

namespace Api.Models.MappingProfiles;

public class RobotDtoProfile : Profile
{
    public RobotDtoProfile()
    {
        CreateMap<Robot, RobotDto>()
            .ForMember(dest => dest.Direction, src => src.MapFrom(x => x.Direction.Name));
        CreateMap<Area, RobotDto.RobotAreaDto>();
    }
}