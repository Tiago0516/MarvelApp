using Marvel.Domain.Entities;
using Marvel.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Marvel.Infrastructure.Data;

namespace Marvel.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly MarvelDbContext _context;
        
        public UsuarioRepository(MarvelDbContext context)
        {
            _context = context;
        }
        
        public async Task<Usuario> ObtenerPorIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }
        
        public async Task<Usuario> RegistrarAsync(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> ObtenerPorEmailAsync(string Correo)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Correo == Correo);
        }
    }
}