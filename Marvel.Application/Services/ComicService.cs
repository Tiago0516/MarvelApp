using Marvel.Application.DTOs;
using Marvel.Domain.Models;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Marvel.Domain.Interfaces;

namespace Marvel.Application.Services
{
    public class ComicService
    {
        private readonly HttpClient _httpClient;
        private readonly string _publicKey;
        private readonly string _privateKey;  
        private readonly IComicRepository _comicRepository;

        public ComicService(HttpClient httpClient, IComicRepository comicRepository,string publicKey, string privateKey)
        {
            _httpClient = httpClient;
            _comicRepository = comicRepository;
             _publicKey = publicKey;
            _privateKey = privateKey;
        }

        private string CrearMd5(string input)
        {
            using var md5 = MD5.Create();
            var inputBytes = Encoding.ASCII.GetBytes(input);
            var hashBytes = md5.ComputeHash(inputBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }

        public async Task<IEnumerable<ComicDto>> ObtenerComicsAsync()
        {
            var ts = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var hash = CrearMd5($"{ts}{_privateKey}{_publicKey}");
            var url = $"https://gateway.marvel.com/v1/public/comics?ts={ts}&apikey={_publicKey}&hash={hash}";


            var response = await _httpClient.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();

               if (!response.IsSuccessStatusCode)
                {
                    return new List<ComicDto>();
                }

            var data = JsonSerializer.Deserialize<MarvelApiResponse>(json, new JsonSerializerOptions {PropertyNameCaseInsensitive = true});

            return data?.Data?.Results?.Select(comic => new ComicDto
                {
                    Id = comic.Id,
                    Title = comic.Title,
                    Description = string.IsNullOrEmpty(comic.Description) ? "Sin descripción" : comic.Description,
                    Thumbnail = comic.Thumbnail != null 
                        ? new Thumbnail { Path = $"{comic.Thumbnail.Path}.{comic.Thumbnail.Extension}" } 
                        : null,
                    Creators = comic.Creators != null 
                        ? new CreatorData { Items = comic.Creators.Items.Select(c => new Creator { Name = c.Name, Role = c.Role }).ToList() } 
                        : new CreatorData { Items = new List<Creator>() },
                    Characters = comic.Characters != null 
                        ? new CharacterData { Items = comic.Characters.Items.Select(c => new Character { Name = c.Name }).ToList() } 
                        : new CharacterData { Items = new List<Character>() },
                    Stories = comic.Stories != null 
                        ? new StoryData { Items = comic.Stories.Items.Select(s => new Story { Name = s.Name, Type = s.Type }).ToList() } 
                        : new StoryData { Items = new List<Story>() }
                }).ToList() ?? new List<ComicDto>();

        }

       

        public async  Task<IEnumerable<ComicDto>> ObtenerComicPorIdAsync(int comicId)
        {
            var ts = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var hash = CrearMd5($"{ts}{_privateKey}{_publicKey}");
            var url = $"https://gateway.marvel.com/v1/public/comics/{comicId}?ts={ts}&apikey={_publicKey}&hash={hash}";

            var response = await _httpClient.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();


            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error en la API de Marvel");
            }

            var jsonData = JsonSerializer.Deserialize<MarvelApiResponse>(json, new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            
            return jsonData?.Data?.Results?.Select(comic => new ComicDto
                {
                    Id = comic.Id,
                    Title = comic.Title,
                    Description = string.IsNullOrEmpty(comic.Description) ? "Sin descripción" : comic.Description,
                    Thumbnail = comic.Thumbnail != null 
                        ? new Thumbnail { Path = $"{comic.Thumbnail.Path}.{comic.Thumbnail.Extension}" } 
                        : null,
                    Creators = comic.Creators != null 
                        ? new CreatorData { Items = comic.Creators.Items.Select(c => new Creator { Name = c.Name, Role = c.Role }).ToList() } 
                        : new CreatorData { Items = new List<Creator>() },
                    Characters = comic.Characters != null 
                        ? new CharacterData { Items = comic.Characters.Items.Select(c => new Character { Name = c.Name }).ToList() } 
                        : new CharacterData { Items = new List<Character>() },
                    Stories = comic.Stories != null 
                        ? new StoryData { Items = comic.Stories.Items.Select(s => new Story { Name = s.Name, Type = s.Type }).ToList() } 
                        : new StoryData { Items = new List<Story>() }
                }).ToList() ?? new List<ComicDto>();
        }
    }
}
