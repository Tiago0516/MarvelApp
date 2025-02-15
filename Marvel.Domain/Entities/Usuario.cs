namespace Marvel.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public string Correo { get; set; }
        public List<Favorito> Favoritos { get; set; } = new();
    }
}