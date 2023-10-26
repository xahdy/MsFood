using AutoMapper;
using Marketplace.Domain.Models;
using Marketplace.Domain.Models.Dto;

namespace Marketplace.Api.Profiles
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
