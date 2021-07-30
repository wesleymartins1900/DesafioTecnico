using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class WebApiContext : DbContext
    {
        public WebApiContext(DbContextOptions<WebApiContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }
    }
}