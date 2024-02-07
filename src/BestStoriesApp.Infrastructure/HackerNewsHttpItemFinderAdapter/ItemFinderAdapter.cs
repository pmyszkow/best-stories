using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BestStoriesApp.Core.Domain.ValueObjects;
using BestStoriesApp.Core.Port.IItemFinder;

namespace BestStoriesApp.Infrastructure.HackerNewsHttpItemFinderAdapter
{
    public class ItemFinderAdapter : IItemFinder
    {
        private readonly HttpClientStub _httpClient;

        public ItemFinderAdapter(HttpClientStub httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async IAsyncEnumerable<ItemId> GetBestStoriesItemIds()
        {
            await foreach (var id in _httpClient.GetBestStoriesItemIds())
            {
                yield return ItemId.FromInt(id);
            }
        }

        public async Task<StoryItemDpo> GetStoryItemById(ItemId id)
        {
            var dto = await _httpClient.GetStoryItemById(id.Value);

            return StoryItemDpo.Create(dto.By,
                dto.Descendants,
                dto.Id,
                dto.Kids,
                dto.Score,
                dto.Time,
                dto.Title,
                dto.Type,
                dto.Url);
        }
    }
}