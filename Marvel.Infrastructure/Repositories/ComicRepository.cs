using Marvel.Domain.Entities;
using Marvel.Domain.Interfaces;
using Marvel.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marvel.Infrastructure.Repositories
{
    public class ComicRepository : IComicRepository
    {
        private readonly MarvelDbContext _context;

        public ComicRepository(MarvelDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comic>> ObtenerTodosAsync()
        {
            return await _context.Comics.ToListAsync();
        }

        public async Task<Comic> ObtenerPorIdAsync(int id)
        {
            return await _context.Comics.FindAsync(id);
        }

        public async Task<Comic> AgregarAsync(Comic comic)
        {
            _context.Comics.Add(comic);
            await _context.SaveChangesAsync();
            return comic;
        }
    }
}
