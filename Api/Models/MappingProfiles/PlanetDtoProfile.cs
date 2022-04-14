using AutoMapper;
using Domain.Models;

namespace Api.Models.MappingProfiles;

public class PlanetDtoProfile : Profile
{
    public PlanetDtoProfile()
    {
        CreateMap<Planet, PlanetDto>();
        CreateMap<Area, PlanetDto.PlanetAreaDto>()
            .ForMember(dest => dest.X, src => src.MapFrom(x => x.X.ToString()))
            .ForMember(dest => dest.Y, src => src.MapFrom(x => x.Y.ToString()));
        CreateMap<Robot, PlanetDto.PlanetAreaDto.AreaRobotDto>();
    }
}