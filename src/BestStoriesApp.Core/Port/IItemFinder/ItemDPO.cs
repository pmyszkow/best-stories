using BestStoriesApp.Core.Domain.ValueObjects;

namespace BestStoriesApp.Core.Port.IItemFinder
{
    public class ItemDPO
    {
        public ItemDPO(ItemId id, UserId by, UnixTimeStamp time, ItemUri url, Score score, Title title, Count descendants)
        {
            Id = id;
            By = by;
            Time = time;
            Url = url;
            Score = score;
            Title = title;
            Descendants = descendants;
        }

        public ItemId Id { get; }

        public UserId By { get; }

        public UnixTimeStamp Time { get; }

        public ItemUri Url { get; }

        public Score Score { get; }

        public Title Title { get; }

        public Count Descendants { get; }
    }
}