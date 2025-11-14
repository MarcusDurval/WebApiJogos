using Project.Web.Api.Domain.Models;

namespace Project.Web.Api.Application.CategoriaService
{
    public interface IcategoriaService
    {
        Task<Categoria_Jogos> Adicionar(Categoria_Jogos categoria);
        Task<List<Categoria_Jogos>> ObterTotal();
        Task<Categoria_Jogos> ObterPorId(int id);
        Task<Categoria_Jogos> Apagar(int id);
        Task<Categoria_Jogos> Atualizar(Categoria_Jogos categoria);
    }
}
