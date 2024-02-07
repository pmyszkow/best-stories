using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BestStoriesApp.Infrastructure.HackerNewsHttpItemFinderAdapter
{
    public class HackerNewsHttpClient
    {
        private readonly HttpClient _httpClient;

        public HackerNewsHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async IAsyncEnumerable<int> GetBestStoriesItemIds()
        {
            var response = await _httpClient.GetAsync($"beststories.json");

            response.EnsureSuccessStatusCode();

            await using var responseStream = await response.Content.ReadAsStreamAsync();
            
            foreach (var id in await JsonSerializer.DeserializeAsync<IEnumerable<int>>(responseStream))
            {
                yield return id;
            }
        }

        public async Task<ItemDto> GetStoryItemById(int id)
        {
            var response = await _httpClient.GetAsync($"item/{id}.json");

            response.EnsureSuccessStatusCode();

            await using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<ItemDto>(responseStream);
        }
    }
}