using AutoMapper;
using JokesApi.Dtos;
using JokesApi.Models;

namespace JokesApi.MapperProfiles
{
    public class JokeMapperProfile : Profile
    {
        public JokeMapperProfile()
        {
            CreateMap<JokeRequestDto, Joke>();
        }
    }
}
