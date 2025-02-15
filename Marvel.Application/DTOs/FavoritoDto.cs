namespace Marvel.Application.DTOs
{     public class FavoriteRequestDto
    {
        public int UsuarioId { get; set; }
        public int ComicId { get; set; }
        public string Title { get; set; }
        public ThumbnailDto Thumbnail { get; set; }
    }

    public class ThumbnailDto
    {
        public string Path { get; set; }
        public string Extension { get; set; }
    }
}