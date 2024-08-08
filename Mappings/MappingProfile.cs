using AutoMapper;
using TvShowApi.Dtos;
using TvShowApi.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TvShowApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TvShow, TvShowApiDto>().ReverseMap();
        }
    }
}
