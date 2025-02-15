namespace Marvel.Domain.Entities
{
   public class Comic
    {
        public int Id { get; set; }
         public int ComicId { get; set; }
          public int UsuarioId { get; set; }
        public string Title { get; set; }
        // Por ejemplo, una URL de imagen ya compuesta
        public string Thumbnail { get; set; }
        // Otras propiedades relevantes para la lógica de negocio
    }
}

