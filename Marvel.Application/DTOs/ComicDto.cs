using System.Text.Json.Serialization;

namespace Marvel.Application.DTOs
{
    
    public class ComicDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("thumbnail")]
        public Thumbnail Thumbnail { get; set; }

        [JsonPropertyName("creators")]
        public CreatorData Creators { get; set; }

        [JsonPropertyName("characters")]
        public CharacterData Characters { get; set; }

        [JsonPropertyName("stories")]
        public StoryData Stories { get; set; }
    }

    public class Thumbnail
    {
        [JsonPropertyName("path")]
        public string Path { get; set; }

        [JsonPropertyName("extension")]
        public string Extension { get; set; }
    }

    public class CreatorData
    {
        [JsonPropertyName("items")]
        public List<Creator> Items { get; set; }
    }

    public class Creator
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; }
    }

    public class CharacterData
    {
        [JsonPropertyName("items")]
        public List<Character> Items { get; set; }
    }

    public class Character
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class StoryData
    {
        [JsonPropertyName("items")]
        public List<Story> Items { get; set; }
    }

    public class Story
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

      public class ComicMarvel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Thumbnail Thumbnail { get; set; }
        public CreatorData Creators { get; set; }
        public CharacterData Characters { get; set; }
        public StoryData Stories { get; set; }
    }
}