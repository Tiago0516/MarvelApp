using Microsoft.EntityFrameworkCore;
using Marvel.Domain.Entities;

namespace Marvel.Infrastructure.Data
{
    public class MarvelDbContext : DbContext
    {
        public MarvelDbContext(DbContextOptions<MarvelDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Comic> Comics { get; set; }
        public DbSet<Favorito> Favoritos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Favorito>().HasKey(f => new { f.UsuarioId, f.ComicId });
        }
    }
}
