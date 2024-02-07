using System;
using System.Collections.ObjectModel;
using System.Linq;
using BestStoriesApp.Core.Domain.ValueObjects;

namespace BestStoriesApp.Core.Port.IItemFinder
{
    public class StoryItemDpo
    {
        private StoryItemDpo(UserId by,
            Count descendants,
            ItemId id,
            ReadOnlyCollection<ItemId> kids,
            Score score,
            UnixTimeStamp time,
            Title title,
            ItemType type,
            ItemUri url)
        {
            By = by;
            Descendants = descendants;
            Id = id;
            Kids = kids;
            Score = score;
            Time = time;
            Title = title;
            Type = type;
            Url = url;
        }

        public static StoryItemDpo Create(UserId by,
            Count descendants,
            ItemId id,
            ReadOnlyCollection<ItemId> kids,
            Score score,
            UnixTimeStamp time,
            Title title,
            ItemType type,
            ItemUri url)
        {
            if (by == null) throw new ArgumentNullException(nameof(by));
            if (descendants == null) throw new ArgumentNullException(nameof(descendants));
            if (id == null) throw new ArgumentNullException(nameof(id));
            if (kids == null) throw new ArgumentNullException(nameof(kids));
            if (score == null) throw new ArgumentNullException(nameof(score));
            if (time == null) throw new ArgumentNullException(nameof(time));
            if (title == null) throw new ArgumentNullException(nameof(title));
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (url == null) throw new ArgumentNullException(nameof(url));

            return new StoryItemDpo(by, descendants, id, kids, score, time, title, type, url);
        }

        public static StoryItemDpo Create(string by,
            int? descendants,
            int? id,
            ReadOnlyCollection<int> kids,
            int? score,
            int? time,
            string title,
            string type,
            string url)
        {
            if (by == null) throw new ArgumentNullException(nameof(by));
            if (descendants == null) throw new ArgumentNullException(nameof(descendants));
            if (id == null) throw new ArgumentNullException(nameof(id));
            if (kids == null) throw new ArgumentNullException(nameof(kids));
            if (score == null) throw new ArgumentNullException(nameof(score));
            if (time == null) throw new ArgumentNullException(nameof(time));
            if (title == null) throw new ArgumentNullException(nameof(title));
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (url == null) throw new ArgumentNullException(nameof(url));

            return new StoryItemDpo(UserId.FromString(by),
                Count.FromInt(descendants.Value),
                ItemId.FromInt(id.Value),
                kids.Select(kid => ItemId.FromInt(kid))
                    .ToList()
                    .AsReadOnly(),
                Score.FromInt(score.Value),
                UnixTimeStamp.FromInt(time.Value),
                Title.FromString(title),
                ItemType.FromString(type),
                ItemUri.FromString(url));
        }

        public UserId By { get; }

        public Count Descendants { get; }

        public ItemId Id { get; }

        public ReadOnlyCollection<ItemId> Kids { get; }

        public Score Score { get; }

        public UnixTimeStamp Time { get; }

        public Title Title { get; }

        public ItemType Type { get; }

        public ItemUri Url { get; }
    }
}