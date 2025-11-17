using AutoMapper;
using PrimerLeague.DTOs;
using PrimerLeague.Models;

namespace PrimerLeague
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Team, TeamDTO>()
           .ForMember(dest => dest.players, opt => opt.MapFrom(src => src.PlayerProfile));

            CreateMap<PlayerProfile, PlayerProfileDto>();

            CreateMap<TeamDTO, Team>();

            CreateMap<PlayerProfile, PlayerProfileDto>()
            .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.CountryName))
            .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team != null ? src.Team.TeamName : null))
            .ForMember(dest => dest.BirthDay, opt => opt.MapFrom(src => src.BirthDay.ToString()));

            CreateMap<PlayerProfileDto, PlayerProfile>();
        }
    }
}
