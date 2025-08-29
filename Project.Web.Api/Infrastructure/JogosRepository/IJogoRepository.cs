using Project.Web.Api.Domain.Models;

namespace Project.Web.Api.Infrastructure.JogosRepository
{
    public interface IJogoRepository
    {
        void Add(Jogos jogos);
        List<Jogos> GetAll();
        Jogos GetById(int id);
        Jogos Delete(int id);
        Jogos Update(Jogos jogos);  
    }
}
