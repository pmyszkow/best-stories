using System;
using System.Collections.Generic;
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

        public async IAsyncEnumerable<StoryDpo> GetTopBestStories(Count top)
        {
            await foreach (var itemDpo in _itemFinder.GetTopBestStoryItems(top))
            {
                yield return StoryDpo.CreateInstance(itemDpo.Title,
                    itemDpo.Url,
                    itemDpo.By,
                    UtcTimeStamp.FromUnixTimeStamp(itemDpo.Time),
                    itemDpo.Score,
                    itemDpo.Descendants);
            }
        }
    }
}