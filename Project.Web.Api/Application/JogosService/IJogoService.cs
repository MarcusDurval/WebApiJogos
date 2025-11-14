using Project.Web.Api.Domain.Models;

namespace Project.Web.Api.Application.Service
{
    public interface IJogoService
    {
        Task<Jogos> Adicionar(Jogos jogos);
        Task<List<Jogos>> ObterTotal(int page, int size);
        Task<Jogos> ObterPorId(int id);
        Task<Jogos> Apagar(int id);
        Task<Jogos> Atualizar(Jogos jogos);
    }
}
