using Microsoft.AspNetCore.Http.HttpResults;
using Project.Web.Api.Domain.Models;
using Project.Web.Api.Infrastructure.Data;

namespace Project.Web.Api.Infrastructure.JogosRepository
{
    public class JogoRepository : IJogoRepository
    {
        private readonly AppDbContext _context;

        public JogoRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Jogos jogos)
        {
            _context.Biblioteca_Jogos.Add(jogos);   
            _context.SaveChanges();
        }

        public Jogos Delete(int id)
        {
            var deleteJogos = _context.Biblioteca_Jogos.FirstOrDefault(d => d.ID_Jogo == id);

            if(deleteJogos != null)
            {
                _context.Biblioteca_Jogos.Remove(deleteJogos);
                _context.SaveChanges();
            }

            
            return deleteJogos;
        }

        public List<Jogos> GetAll()
        {
            return _context.Biblioteca_Jogos.ToList();
        }

        public Jogos GetById(int id)
        {
            return _context.Biblioteca_Jogos.Find(id);
        }

        public Jogos Update(Jogos jogos)
        {
            var updateJogos = _context.Biblioteca_Jogos.Find(jogos.ID_Jogo);
            if (updateJogos != null)
            {
                updateJogos.Nome = jogos.Nome;

                _context.SaveChanges(); 
            }

          

            return updateJogos;
        }
    }
}
