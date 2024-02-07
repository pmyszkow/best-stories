using System.Collections.Generic;
using System.Threading.Tasks;
using BestStoriesApp.Core.Domain.ValueObjects;

namespace BestStoriesApp.Core.Port.IItemFinder
{
    public interface IItemFinder
    {
        IAsyncEnumerable<StoryItemDpo> GetTopBestStoryItems(Count top);

        IAsyncEnumerable<StoryItemDpo> GetBestStoryItems();

        IAsyncEnumerable<ItemId> GetBestStoryItemsIds();

        Task<StoryItemDpo> GetStoryItemById(ItemId id);
    }
}