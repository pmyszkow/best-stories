using System;
using BestStoriesApp.Core.Domain.ValueObjects;

namespace BestStoriesApp.Core.Port.IStoryQueryService
{
    public class StoryDPO
    {
        public StoryDPO(Title title, ItemUri uri, UserId postedBy, UnixTimeStamp time, Score score, Count commentCount)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Uri = uri ?? throw new ArgumentNullException(nameof(uri));
            PostedBy = postedBy ?? throw new ArgumentNullException(nameof(postedBy));
            Time = time ?? throw new ArgumentNullException(nameof(time));
            Score = score ?? throw new ArgumentNullException(nameof(score));
            CommentCount = commentCount ?? throw new ArgumentNullException(nameof(commentCount));
        }

        public Title Title { get; }

        public ItemUri Uri { get; }

        public UserId PostedBy { get; }

        public UnixTimeStamp Time { get; }

        public Score Score { get; }

        public Count CommentCount { get; }
    }
}