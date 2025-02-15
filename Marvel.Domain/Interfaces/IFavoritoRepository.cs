using System.Collections.Generic;
using System.Threading.Tasks;
using Marvel.Domain.Entities; 

namespace Marvel.Domain.Interfaces
{
    public interface IFavoritoRepository
    {
         Task AgregarAsync(Favorito favorito);
        Task AgregarFavoritoAsync(Favorito favorito);
        Task EliminarFavoritoAsync(int usuarioId, int comicId);
        Task<IEnumerable<Comic>> ObtenerFavoritosPorUsuarioAsync(int usuarioId);
    }
}
