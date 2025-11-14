using Project.Web.Api.Domain.Models;
using Project.Web.Api.Infrastructure.JogosRepository;

namespace Project.Web.Api.Application.Service
{
    public class JogoService : IJogoService
    {
        private readonly IJogoRepository _jogorepository;
        public JogoService(IJogoRepository jogorepository)
        {
            _jogorepository = jogorepository;
        }
        public async Task<Jogos> Adicionar(Jogos jogos)
        {
            if (jogos == null) throw new ArgumentNullException(nameof(jogos));
            if (string.IsNullOrWhiteSpace(jogos.Nome)) throw new ArgumentNullException("Nome do jogo é obrigatorio");

            if (jogos.Nome.Length > 200) throw new ArgumentNullException("Nome muito grande");

            await _jogorepository.Add(jogos);

            return jogos;
        }

        public async Task<Jogos> Apagar(int id)
        {
            var existing = await _jogorepository.GetById(id);

            if (existing == null) throw new Exception("Jogo não encontrado.");

            return await _jogorepository.Delete(id);
        }

        public async Task<Jogos> Atualizar(Jogos jogos)
        {
            if(jogos == null) throw new ArgumentNullException(nameof(jogos));
            var existing = await _jogorepository.GetById(jogos.ID_Jogo);

            if (existing == null)
            {
                throw new Exception("Jogo não encontrado.");
            }

            existing.Nome =jogos.Nome ?? existing.Nome;

            return await _jogorepository.Update(existing);
        }

        public async Task<Jogos> ObterPorId(int id)
        {
            var jogo = await _jogorepository.GetById(id);

            if (jogo == null) throw new ArgumentNullException("Jogo não encontrado");

            return jogo;
        }

        public async Task<List<Jogos>> ObterTotal(int page, int size)
        {
            if (page <= 0) page = 1;
            if (size <= 0) size = 10;
            return await _jogorepository.GetById(page, size);
        }
    }
}
