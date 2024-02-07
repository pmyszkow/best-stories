using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BestStoriesApp.Infrastructure.HackerNewsHttpItemFinderAdapter
{
    public class ItemDto
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("deleted")]
        public bool? Deleted { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("by")]
        public string By { get; set; }

        [JsonPropertyName("time")]
        public int? Time { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("dead")]
        public bool? Dead { get; set; }

        [JsonPropertyName("parent")]
        public int? Parent { get; set; }

        [JsonPropertyName("poll")]
        public int? Poll { get; set; }

        [JsonPropertyName("kids")]
        public List<int> Kids { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("score")]
        public int? Score { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("parts")]
        public List<int> Parts { get; set; }

        [JsonPropertyName("descendants")]
        public int? Descendants { get; set; }
    }
}