using Microsoft.AspNetCore.Mvc;
using Marvel.Application.Services;
using System.Threading.Tasks;

namespace Marvel.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ComicsController : ControllerBase
    {
        private readonly ComicService _comicService;

        public ComicsController(ComicService comicService)
        {
            _comicService = comicService;
        }

      [HttpGet("comics")]
        public async Task<IActionResult> ObtenerComics()
        {
            var comics = await _comicService.ObtenerComicsAsync();
            return Ok(comics);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerComicPorId(int id)
        {
            var comic = await _comicService.ObtenerComicPorIdAsync(id);
            if (comic == null)
                return NotFound("Cómic no encontrado.");

            return Ok(comic);
        }
    }
}
