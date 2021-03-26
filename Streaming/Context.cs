using Microsoft.EntityFrameworkCore;
using Streaming.Models;

namespace Streaming
{
    public class Context : DbContext
    {
        public DbSet<Genero> Genero { get; set; }
        public DbSet<Filmes> Filmes { get; set; }
        public DbSet<Series> Series { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer("Server=DESKTOP-0E2MGV9\\SQLEXPRESS; Database=Streaming; Trusted_Connection=True");
        }
    }
}
