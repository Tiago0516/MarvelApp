using Marvel.Domain.Interfaces;
using Marvel.Application.DTOs;
using Marvel.Domain.Entities;

namespace Marvel.Application.Services
{
    public class FavoritoService
    {
        private readonly IFavoritoRepository _favoritoRepository;
        
        public FavoritoService(IFavoritoRepository favoritoRepository)
        {
            _favoritoRepository = favoritoRepository;
        }
        
        
        public async Task AgregarFavoritoAsync(Favorito favorito)
        {
            await _favoritoRepository.AgregarAsync(favorito);
        }




        public async Task EliminarFavoritoAsync(int usuarioId, int comicId)
        {
            await _favoritoRepository.EliminarFavoritoAsync(usuarioId, comicId);
        }

        public async Task<IEnumerable<Comic>> ObtenerFavoritosPorUsuarioAsync(int usuarioId)
        {
            return await _favoritoRepository.ObtenerFavoritosPorUsuarioAsync(usuarioId);
        }
    }
}