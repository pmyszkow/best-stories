using System.Collections.Generic;
using System.Threading.Tasks;
using BestStoriesApp.Core.Domain.ValueObjects;
using BestStoriesApp.Core.Port.IItemFinder;

namespace BestStoriesApp.Infrastructure.HackerNewsHttpItemFinderAdapter
{
    public class ItemFinderAdapter : IItemFinder
    {
        public async IAsyncEnumerable<ItemId> GetBestStoriesItemIds()
        {
            yield return await Task.FromException<ItemId>(new System.NotImplementedException());
        }

        public async Task<StoryItemDpo> GetStoryItemById(ItemId id)
        {
            return await Task.FromException<StoryItemDpo>(new System.NotImplementedException());
        }
    }
}