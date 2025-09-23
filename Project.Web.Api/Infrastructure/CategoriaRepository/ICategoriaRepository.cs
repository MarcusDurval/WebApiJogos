using Project.Web.Api.Domain.Models;

namespace Project.Web.Api.Infrastructure.CategoriaRepository
{
    public interface ICategoriaRepository
    {
        Task Add(Categoria_Jogos categoria);
        Task<List<Categoria_Jogos>> GetAll();
        Task<Categoria_Jogos> GetById(int id);
        Task<Categoria_Jogos> Delete(int id);
        Task<Categoria_Jogos> Update(Categoria_Jogos categoria);
       
    }
}
