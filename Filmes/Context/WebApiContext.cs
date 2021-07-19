using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Data.Context
{
    public class WebApiContext : DbContext
    {
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var stringConexao = ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString;

            optionsBuilder.UseSqlServer(stringConexao);
            base.OnConfiguring(optionsBuilder);
        }
    }
}