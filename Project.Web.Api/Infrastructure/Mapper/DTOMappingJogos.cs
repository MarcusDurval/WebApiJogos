using AutoMapper;
using Project.Web.Api.Domain.JogoDTO;
using Project.Web.Api.Domain.Models;

namespace Project.Web.Api.Infrastructure.Mapper
{
    public class DTOMappingJogos : Profile
    {
        public DTOMappingJogos()
        {
            CreateMap<Jogos, JogosDto>();

            CreateMap<JogosDto, Jogos>();
        }
    }
}
