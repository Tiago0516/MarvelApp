using Marvel.Domain.Interfaces;
using Marvel.Domain.Entities;
using Marvel.Application.DTOs;

namespace Marvel.Application.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        
        public async Task<UsuarioDto> RegistrarUsuarioAsync(UsuarioDto usuarioDto)
        {
            var usuario = new Usuario
            {
                Id = usuarioDto.Id,
                Nombre = usuarioDto.Nombre,
                Identificacion = usuarioDto.Identificacion,
                Correo = usuarioDto.Correo
            };
            var usuarioRegistrado = await _usuarioRepository.RegistrarAsync(usuario);
            return new UsuarioDto
            {
                Nombre = usuarioRegistrado.Nombre,
                Identificacion = usuarioRegistrado.Identificacion,
                Correo = usuarioRegistrado.Correo
            };
        }

        public async Task<UsuarioDto> AutenticarUsuarioAsync(string Correo, string Identificacion)
        {
            var usuario = await _usuarioRepository.ObtenerPorEmailAsync(Correo);

            if (usuario == null || usuario.Identificacion != Identificacion)
                throw new Exception("Credenciales incorrectas");

            return new UsuarioDto
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo
            };
        }

    }
}