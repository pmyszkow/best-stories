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

        public async IAsyncEnumerable<StoryDpo> GetTopBestStories(Count count)
        {
            await foreach (var item in _itemFinder.GetTopBestStoryItems(count))
            {
                yield return StoryDpo.CreateInstance(item.Title,
                    item.Url,
                    item.By,
                    UtcTimeStamp.FromUnixTimeStamp(item.Time),
                    item.Score,
                    item.Descendants);
            }
        }
    }
}