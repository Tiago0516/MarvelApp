using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marvel.Domain.Entities
{
    public class Favorito
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public int UsuarioId { get; set; }
        public int ComicId { get; set; }
        public string Title { get; set; }
        public string Thumbnail { get; set; }
    }
}
