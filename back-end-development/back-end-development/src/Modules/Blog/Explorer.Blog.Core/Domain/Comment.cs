using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Stakeholders.Core.Domain;
using System.Text.Json.Serialization;

namespace Explorer.Blog.Core.Domain
{
    public class Comment : ValueObject
    { 
        public string Context { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public long UserId { get; set; }

        [JsonConstructor]
        public Comment(string context, DateTime creationTime, DateTime lastUpdateTime, long userId)
        {
            if (string.IsNullOrWhiteSpace(context)) throw new ArgumentException("Invalid Comment.");
            if (!DateTime.TryParse(creationTime.GetDateTimeFormats().FirstOrDefault(), out _)) throw new ArgumentException("Invalid Date.");

            Context = context;
            CreationTime = new DateTime(creationTime.Ticks);
            LastUpdateTime = new DateTime(lastUpdateTime.Ticks);
            UserId = userId;
        }

        public void ChangeComment(Comment comment)
        {
            Context = comment.Context;
            LastUpdateTime = new DateTime(DateTime.Now.Ticks);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return UserId;
            yield return Context;
            yield return CreationTime;
            yield return LastUpdateTime;

        }
    }
}
