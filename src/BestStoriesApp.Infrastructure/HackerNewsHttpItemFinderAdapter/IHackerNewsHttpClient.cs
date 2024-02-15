using System.Collections.Generic;
using System.Threading.Tasks;

namespace BestStoriesApp.Infrastructure.HackerNewsHttpItemFinderAdapter
{
    public interface IHackerNewsHttpClient
    {
        IAsyncEnumerable<int> GetBestStoriesItemIds();
        Task<ItemDto> GetStoryItemById(int id);
    }
}