using System.Collections.Generic;

namespace Marvel.Application.DTOs
{
    public class MarvelApiResponse
    {
        public MarvelData Data { get; set; }
    }

    public class MarvelData
    {
        public List<ComicMarvel> Results { get; set; }
    }
}
