using AutoMapper;
using Cadastro.Domain.Models;
using Cadastro.Domain.Models.Dto;

namespace Cadastro.Api.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Restaurante, RestauranteDto>();
            CreateMap<RestauranteDto, Restaurante>();

            CreateMap<Prato, PratoDto>();
            CreateMap<PratoDto, Prato>();

            CreateMap<Localizacao, LocalizacaoDto>();
            CreateMap<LocalizacaoDto, Localizacao>();
        }
    }
}
