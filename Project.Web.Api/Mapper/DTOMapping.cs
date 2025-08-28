using AutoMapper;
using Project.Web.Api.JogoDTO;
using Project.Web.Api.Models;

namespace Project.Web.Api.Mapper
{
    public class DTOMapping : Profile
    {
        public DTOMapping()
        {
            CreateMap<Jogos, JogosDto>();

            CreateMap<JogosDto, Jogos>();
        }
    }
}
