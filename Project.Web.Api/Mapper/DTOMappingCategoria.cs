using AutoMapper;
using Project.Web.Api.Domain.CategoriaDTO;
using Project.Web.Api.Domain.Models;

namespace Project.Web.Api.Mapper
{
    public class DTOMappingCategoria : Profile
    {
        public DTOMappingCategoria()
        {
            CreateMap<Categoria_Jogos, CategoriasDTO>();

            CreateMap<CategoriasDTO, Categoria_Jogos>();
        }
    }
}
