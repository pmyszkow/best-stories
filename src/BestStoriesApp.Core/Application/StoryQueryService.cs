using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BestStoriesApp.Core.Domain.ValueObjects;
using BestStoriesApp.Core.Port.IItemFinder;
using BestStoriesApp.Core.Port.IStoryQueryService;

namespace BestStoriesApp.Core.Application
{
    public class StoryQueryService : IStoryQueryService
    {
        private readonly IItemFinder _itemFinder;

        public StoryQueryService(IItemFinder itemFinder)
        {
            _itemFinder = itemFinder ?? throw new ArgumentNullException(nameof(itemFinder));
        }

        public async IAsyncEnumerable<StoryDPO> GetTopBestStories(Count count)
        {
            yield return await Task.FromException<StoryDPO>(new System.NotImplementedException());
        }
    }
}