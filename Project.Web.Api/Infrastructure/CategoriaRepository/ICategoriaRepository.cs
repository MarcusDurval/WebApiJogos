using Project.Web.Api.Domain.Models;

namespace Project.Web.Api.Infrastructure.CategoriaRepository
{
    public interface ICategoriaRepository
    {
        void Add(Categoria_Jogos categoria);
        List<Categoria_Jogos> GetAll();
        Categoria_Jogos GetById(int id);
        Categoria_Jogos Delete (int id);
        Categoria_Jogos Update(Categoria_Jogos categoria);
    }
}
