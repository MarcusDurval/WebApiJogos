using Microsoft.AspNetCore.Http.HttpResults;
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

        public async Task Add(Categoria_Jogos categoria)
        {
            try
            {
                appDbContext.Categoria_Jogos.Add(categoria);
                await appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao adicionar dados na categoria de jogos: {ex.Message}");
            }
        }

        public async Task<Categoria_Jogos> Delete(int id)
        {
            try
            {
                var CategoriaJogos = await appDbContext.Categoria_Jogos.FirstOrDefaultAsync(i => i.ID == id);
                if (CategoriaJogos == null)
                {
                    throw new Exception("Algo deu errado,ao obter dados por identificador!");
                }
                else
                {
                    appDbContext.Categoria_Jogos.Remove(CategoriaJogos);
                    await appDbContext.SaveChangesAsync();
                }

                return CategoriaJogos;
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao remover dados da categoria {ex.Message}");
            }
        }
        public async Task<List<Categoria_Jogos>> GetAll()
        {
            try
            {
                var ObterCategoria = await appDbContext.Categoria_Jogos.ToListAsync();
                foreach (var item in ObterCategoria)
                {
                    item.Jogos = await appDbContext.Biblioteca_Jogos.FirstOrDefaultAsync(j => j.ID_Jogo == item.JogoId);
                }

                return ObterCategoria;
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao ObterDados de categoria: {ex.Message}");
            }
        }

        public async Task<Categoria_Jogos> GetById(int id)
        {
            try
            {
                var ObterId = await appDbContext.Categoria_Jogos.FindAsync(id);
               
                return ObterId;
            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao ObterDados por identificador{ex.Message}");
            }
        }

        public async Task<Categoria_Jogos> Update(Categoria_Jogos categoria)
        {
            try
            {
                var categoriaAtualizada = await appDbContext.Categoria_Jogos.FindAsync(categoria.ID);

                if (categoriaAtualizada != null)
                {
                    categoriaAtualizada.Categoria = categoria.Categoria;
                    categoriaAtualizada.JogoId = categoria.JogoId;
                }
                else
                {
                    throw new Exception("Categoria não encontrada para atualização.");
                }

                return categoriaAtualizada;

            }
            catch (Exception ex)
            {

                throw new Exception($"Erro ao Atualizar categoria:{ex.Message}");
            }

        }
    }
}
