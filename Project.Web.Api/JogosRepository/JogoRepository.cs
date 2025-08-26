using Project.Web.Api.Data;
using Project.Web.Api.Models;

namespace Project.Web.Api.Repositories
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

        public List<Jogos> GetAll()
        {
            return _context.Biblioteca_Jogos.ToList();
        }
    }
}
