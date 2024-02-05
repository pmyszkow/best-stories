using System.Collections.Generic;
using System.Threading.Tasks;
using BestStoriesApp.Core.Domain.ValueObjects;

namespace BestStoriesApp.Core.Port.IItemFinder
{
    public interface IItemFinder
    {
        IAsyncEnumerable<ItemId> GetBestStoriesItemIds();

        Task<ItemDPO> GetItemById(ItemId id);
    }
}