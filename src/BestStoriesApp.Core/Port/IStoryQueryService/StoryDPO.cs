using System;
using BestStoriesApp.Core.Domain.ValueObjects;

namespace BestStoriesApp.Core.Port.IStoryQueryService
{
    public class StoryDpo
    {
        private StoryDpo(Title title, ItemUri uri, UserId postedBy, UtcTimeStamp time, Score score, Count commentCount)
        {
            Title = title;
            Uri = uri;
            PostedBy = postedBy;
            Time = time;
            Score = score;
            CommentCount = commentCount;
        }

        public static StoryDpo CreateInstance(Title title, ItemUri uri, UserId postedBy, UtcTimeStamp time, Score score, Count commentCount)
        {
            if (title == null) throw new ArgumentNullException(nameof(title));
            if (uri == null) throw new ArgumentNullException(nameof(uri));
            if (postedBy == null) throw new ArgumentNullException(nameof(postedBy));
            if (time == null) throw new ArgumentNullException(nameof(time));
            if (score == null) throw new ArgumentNullException(nameof(score));
            if (commentCount == null) throw new ArgumentNullException(nameof(commentCount));

            return new StoryDpo(title, uri, postedBy, time, score, commentCount);
        }

        public Title Title { get; }

        public ItemUri Uri { get; }

        public UserId PostedBy { get; }

        public UtcTimeStamp Time { get; }

        public Score Score { get; }

        public Count CommentCount { get; }
    }
}