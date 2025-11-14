using Project.Web.Api.Domain.Models;
using Project.Web.Api.Infrastructure.CategoriaRepository;

namespace Project.Web.Api.Application.CategoriaService
{
    public class CategoriaService : IcategoriaService
    {
        private readonly ICategoriaRepository _Cateoriarepository;
        public CategoriaService(ICategoriaRepository repository)
        {
            _Cateoriarepository = repository;   
        }

        public async Task<Categoria_Jogos> Adicionar(Categoria_Jogos categoria)
        {
            if (categoria == null) throw new ArgumentNullException(nameof(categoria));
            if (string.IsNullOrWhiteSpace(categoria.Categoria)) throw new ArgumentNullException("Categoria não encontrado");

            var categories = await _Cateoriarepository.GetAll();

            await _Cateoriarepository.Add(categoria);

            return categoria;
        }

        public async Task<Categoria_Jogos> Apagar(int id)
        {
            var existente = await _Cateoriarepository.GetById(id);
            if(existente == null) throw new ArgumentNullException("categoria não encontrada");
            return await _Cateoriarepository.Delete(id);
        }

        public async Task<Categoria_Jogos> Atualizar(Categoria_Jogos categoria)
        {
            if(categoria == null) throw new ArgumentNullException(nameof(categoria));
            var existente = await _Cateoriarepository.GetById(categoria.JogoId);
            if (string.IsNullOrEmpty(categoria.Categoria)) throw new Exception("Categoria não encotrada.");

            existente.Categoria = categoria.Categoria ?? existente.Categoria;

            return await _Cateoriarepository.Update(categoria);
        }

        public async Task<Categoria_Jogos> ObterPorId(int id)
        {
            var cat = await _Cateoriarepository.GetById(id);
            if (cat == null) throw new Exception("Categoria não encontrada.");
            return cat;
        }

        public async Task<List<Categoria_Jogos>> ObterTotal()
        {
            return await _Cateoriarepository.GetAll();
        }
    }
}
