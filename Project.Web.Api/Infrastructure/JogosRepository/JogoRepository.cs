using Azure.Messaging;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project.Web.Api.Domain.Models;
using Project.Web.Api.Infrastructure.Data;
using System.Drawing;

namespace Project.Web.Api.Infrastructure.JogosRepository
{
    public class JogoRepository : IJogoRepository
    {
        private readonly AppDbContext _context;

        public JogoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(Jogos jogos)
        {
            _context.Biblioteca_Jogos.Add(jogos);
            await _context.SaveChangesAsync();
        }

        public async Task<Jogos> Delete(int id)
        {
            var jogos =  await _context.Biblioteca_Jogos.FirstOrDefaultAsync(j => j.ID_Jogo == id);
            if(jogos != null)
            {
                _context.Biblioteca_Jogos.Remove(jogos);
                await _context.SaveChangesAsync();
            }
             return jogos;
        }

        public async Task<List<Jogos>> GetAll(int page, int size)
        {
            return await _context.Biblioteca_Jogos
                .Skip((page -1) * size)
                .Take(size)
                .ToListAsync();
        }

        public async Task<Jogos> GetById(int id)
        {
           var ObterJogos = await _context.Biblioteca_Jogos.FindAsync(id);

            if(ObterJogos == null)
            {
                return null;
            }

            return ObterJogos;
        }

        public async Task<Jogos> Update(Jogos jogos)
        {
            var jogosAtualizados = await _context.Biblioteca_Jogos.FindAsync(jogos.ID_Jogo);
            if(jogosAtualizados != null)
            {
                jogosAtualizados.Nome = jogos.Nome;
                await _context.SaveChangesAsync();
            }

            return jogosAtualizados;
        }
    }
}
