namespace Marvel.Application.DTOs
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public string Correo { get; set; }
    }
    public class UsuarioLoginDto
    {
        public string Correo { get; set; }
        public string Identificacion { get; set; }
    }
}