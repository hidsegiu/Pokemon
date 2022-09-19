using AutoMapper;
using Pokedex.Web.Data;
using Pokedex.Web.Models;

namespace LeaveManagement.Application.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Pokemon, PokemonCreateVM>().ReverseMap();
            CreateMap<Pokemon, PokemonVM>().ReverseMap();
            CreateMap<Pokemon, PokemonIndexVM>().ReverseMap();
            CreateMap<Pokemon, PokemonDetailsVM>().ReverseMap();

        }
    }
}
