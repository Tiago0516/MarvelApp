using Microsoft.AspNetCore.Mvc;
using Marvel.Application.Services;
using System.Threading.Tasks;
using Marvel.Application.DTOs;
using Marvel.Domain.Entities; // Para Favorite
using Marvel.Application.Services; 


namespace Marvel.API.Controllers
{
    [Route("api/favoritos")]
    [ApiController]
    public class FavoritosController : ControllerBase
    {
        private readonly FavoritoService _favoritoService;

        public FavoritosController(FavoritoService favoritoService)
        {
            _favoritoService = favoritoService;
        }


        [HttpPost]
        public async Task<IActionResult> AgregarFavorito([FromBody] FavoriteRequestDto request)
        {
            // Procesar datos y crear la entidad Favorite
            var favorite = new Favorito
            {
                UsuarioId = request.UsuarioId,
                ComicId = request.ComicId,
                Title = request.Title,
                Thumbnail = (request.Thumbnail != null &&
                             !string.IsNullOrEmpty(request.Thumbnail.Path))
                                ? $"{request.Thumbnail.Path}"
                                : null
            };

            try
            {
                await _favoritoService.AgregarFavoritoAsync(favorite);
                return Ok(new { message = "Cómic agregado a favoritos" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al agregar favorito", error = ex.Message });
            }
        }


      [HttpDelete("{usuarioId}/{comicId}")]
    public async Task<IActionResult> EliminarFavorito(int usuarioId, int comicId)
    {
        await _favoritoService.EliminarFavoritoAsync(usuarioId, comicId);
        return Ok(new { message = "Favorito eliminado correctamente." });
    }


        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> ObtenerFavoritos(int usuarioId)
        {
            var favoritos = await _favoritoService.ObtenerFavoritosPorUsuarioAsync(usuarioId);
            return Ok(favoritos);
        }
    }
}
