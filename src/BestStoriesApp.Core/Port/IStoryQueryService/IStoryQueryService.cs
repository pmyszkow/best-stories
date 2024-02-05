using System.Collections.Generic;
using BestStoriesApp.Core.Domain.ValueObjects;

namespace BestStoriesApp.Core.Port.IStoryQueryService
{
    public interface IStoryQueryService
    {
        IAsyncEnumerable<StoryDPO> GetTopBestStories(Count count);
    }
}