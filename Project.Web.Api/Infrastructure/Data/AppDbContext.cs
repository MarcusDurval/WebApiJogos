using Microsoft.EntityFrameworkCore;
using Project.Web.Api.Domain.Models;

namespace Project.Web.Api.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Categoria_Jogos>()
                .HasOne(j => j.Jogos)
                .WithMany(c => c.Categoria)
                .HasForeignKey(j => j.JogoId);
        }

        public DbSet<Jogos> Biblioteca_Jogos { get; set; }
        public DbSet<Categoria_Jogos> Categoria_Jogos { get; set; }

       
    }
}
