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
            await foreach (var itemId in _itemFinder.GetBestStoriesItemIds())
            {
                var storyItem = await _itemFinder.GetStoryItemById(itemId);

                yield return StoryDpo.CreateInstance(storyItem.Title,
                    storyItem.Url,
                    storyItem.By,
                    UtcTimeStamp.FromUnixTimeStamp(storyItem.Time),
                    storyItem.Score,
                    storyItem.Descendants);
            }
        }
    }
}