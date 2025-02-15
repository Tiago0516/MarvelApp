using Marvel.Domain.Entities;
using Marvel.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Marvel.Infrastructure.Data;

namespace Marvel.Infrastructure.Repositories
{
    public class FavoritoRepository : IFavoritoRepository
    {
        private readonly MarvelDbContext _context;
        
        public FavoritoRepository(MarvelDbContext context)
        {
            _context = context;
        }
        
        public async Task AgregarAsync(Favorito favorito)
        {
            await _context.Favoritos.AddAsync(favorito); 
            await _context.SaveChangesAsync(); 
        }
        public async Task AgregarFavoritoAsync(Favorito favorito)
        {
            _context.Favoritos.Add(favorito);
            await _context.SaveChangesAsync();
        }
        
       public async Task EliminarFavoritoAsync(int usuarioId, int comicId)
        {
            // Buscar el registro favorito que coincida con el usuario y el comicId
            var favorito = await _context.Favoritos
                .FirstOrDefaultAsync(f => f.UsuarioId == usuarioId && f.ComicId == comicId);
            
            // Si se encuentra, se elimina
            if (favorito != null)
            {
                _context.Favoritos.Remove(favorito);
                await _context.SaveChangesAsync();
            }
        }
        
      public async Task<IEnumerable<Comic>> ObtenerFavoritosPorUsuarioAsync(int usuarioId)
        {
            return await _context.Favoritos
                .Where(f => f.UsuarioId == usuarioId)
                .Select(f => new Comic 
                {
                   UsuarioId = f.UsuarioId,
                    ComicId = f.ComicId,
                    Title = f.Title,
                    Thumbnail = f.Thumbnail
                    
                })
                .ToListAsync();
        }

    }
}