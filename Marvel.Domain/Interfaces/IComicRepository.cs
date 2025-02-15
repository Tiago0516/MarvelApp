using Marvel.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Marvel.Domain.Interfaces
{
    public interface IComicRepository
    {
        Task<IEnumerable<Comic>> ObtenerTodosAsync();
        Task<Comic> ObtenerPorIdAsync(int id);
        Task<Comic> AgregarAsync(Comic comic);
    }
}
