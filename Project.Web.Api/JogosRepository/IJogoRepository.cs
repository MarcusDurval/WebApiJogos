using Project.Web.Api.Models;

namespace Project.Web.Api.Repositories
{
    public interface IJogoRepository
    {
        void Add(Jogos jogos);
        List<Jogos> GetAll();
    }
}
