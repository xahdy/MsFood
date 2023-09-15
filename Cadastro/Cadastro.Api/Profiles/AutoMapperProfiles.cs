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
            CreateMap<Prato, PratoDto>();
            CreateMap<Localizacao, LocalizacaoDto>();
        }
    }
}
