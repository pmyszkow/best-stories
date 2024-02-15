using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestStoriesApp.Core.Domain.ValueObjects;
using BestStoriesApp.Core.Port.IItemFinder;

namespace BestStoriesApp.Infrastructure.HackerNewsHttpItemFinderAdapter
{
    public class ItemFinderAdapter : IItemFinder
    {
        private readonly IHackerNewsHttpClient _httpClient;

        public ItemFinderAdapter(IHackerNewsHttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async IAsyncEnumerable<StoryItemDpo> GetTopBestStoryItems(Count top)
        {
            await foreach (var itemDpo in GetBestStoryItems().OrderByDescending(item => item.Score, Score.Comparer).Take(top.Value))
            {
                yield return itemDpo;
            }
        }

        public async IAsyncEnumerable<StoryItemDpo> GetBestStoryItems()
        {
            await foreach (var itemId in GetBestStoryItemsIds())
            {
                yield return await GetStoryItemById(itemId);
            }
        }

        public async IAsyncEnumerable<ItemId> GetBestStoryItemsIds()
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