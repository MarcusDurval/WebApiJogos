using Project.Web.Api.Models;

namespace Project.Web.Api.CategoriaRepository
{
    public interface ICategoriaRepository
    {
        void Add(Categoria_Jogos categoria);
        List<Categoria_Jogos> GetAll();
    }
}
