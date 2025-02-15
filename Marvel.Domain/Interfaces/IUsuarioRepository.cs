using Marvel.Domain.Entities; 

namespace Marvel.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObtenerPorIdAsync(int id);
        Task<Usuario> RegistrarAsync(Usuario usuario);
        Task<Usuario> ObtenerPorEmailAsync(string Correo);

    }
}
