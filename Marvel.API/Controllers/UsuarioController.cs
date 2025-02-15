using Microsoft.AspNetCore.Mvc;
using Marvel.Application.Services;
using Marvel.Domain.Entities;
using System.Threading.Tasks;
using Marvel.Application.DTOs;

namespace Marvel.API.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuariosController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegistrarUsuario([FromBody] UsuarioDto UsuarioDto)
        {
            var resultado = await _usuarioService.RegistrarUsuarioAsync(UsuarioDto);
            return Ok(resultado);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginDto usuarioDto)
        {
            if (usuarioDto == null)
                return BadRequest("El cuerpo de la solicitud está vacío.");

            if (string.IsNullOrEmpty(usuarioDto.Identificacion))
                return BadRequest("El campo Identificacion es obligatorio.");

            var resultado = await _usuarioService.AutenticarUsuarioAsync(usuarioDto.Correo, usuarioDto.Identificacion);
            if (resultado == null)
                return Unauthorized("Credenciales incorrectas.");

            return Ok(resultado);
        }

    }
}
