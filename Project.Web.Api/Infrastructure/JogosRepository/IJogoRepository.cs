using Project.Web.Api.Domain.Models;

namespace Project.Web.Api.Infrastructure.JogosRepository
{
    public interface IJogoRepository
    {
        Task Add(Jogos jogos);
        Task <List<Jogos>> GetAll(int page, int size);
        Task<Jogos> GetById(int id);
        Task<Jogos> Delete(int id);
        Task<Jogos> Update(Jogos jogos);  
    }
}
