using Microsoft.EntityFrameworkCore;
using Project.Web.Api.Data;
using Project.Web.Api.Models;

namespace Project.Web.Api.CategoriaRepository
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

        public List<Categoria_Jogos> GetAll()
        {
            var categoria = appDbContext.Categoria_Jogos.ToList();
            foreach(var categorias in categoria)
            {
                categorias.Jogos = appDbContext.Biblioteca_Jogos.FirstOrDefault(j => j.ID_Jogo == categorias.JogoId);
            }
            return categoria;
        }
    }
}
