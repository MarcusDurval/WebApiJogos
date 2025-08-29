using Microsoft.EntityFrameworkCore;
using Project.Web.Api.Domain.Models;
using Project.Web.Api.Infrastructure.Data;

namespace Project.Web.Api.Infrastructure.CategoriaRepository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDbContext appDbContext;

        public CategoriaRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public void Add(Categoria_Jogos categoria)
        {
            appDbContext.Categoria_Jogos.Add(categoria);
            appDbContext.SaveChanges();
        }

        public Categoria_Jogos Delete(int id)
        {
            var deleteCategorias = appDbContext.Categoria_Jogos.Find(id);

            if(deleteCategorias != null)
            {
                appDbContext.Remove(deleteCategorias);
                appDbContext.SaveChanges(true);
            }

            return deleteCategorias;
        }

        public List<Categoria_Jogos> GetAll()
        {
            var categoria = appDbContext.Categoria_Jogos.ToList();
            foreach(var categorias in categoria)
            {
                categorias.Jogos = appDbContext.Biblioteca_Jogos.FirstOrDefault(j => j.ID_Jogo == categorias.JogoId);
            }
            return categoria;
        }

        public Categoria_Jogos GetById(int id)
        {
            return appDbContext.Categoria_Jogos.Find(id);
        }

        public Categoria_Jogos Update(Categoria_Jogos categoria)
        {
            var updateCategoria = appDbContext.Categoria_Jogos.Find(categoria.ID);

            if(updateCategoria != null)
            {
                updateCategoria.Categoria = categoria.Categoria;
                updateCategoria.JogoId = categoria.JogoId;

                appDbContext.SaveChanges();
            }

            return updateCategoria;

        }
    }
}
