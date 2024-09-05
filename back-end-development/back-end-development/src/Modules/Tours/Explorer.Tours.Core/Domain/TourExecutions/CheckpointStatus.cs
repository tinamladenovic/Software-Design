using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain.TourExecutions
{
    public class CheckpointStatus : ValueObject
    {
        public long CheckpointId { get; init; }
        public bool IsCompleted { get; private set; }
        public DateTime? CompletionTime { get; private set; }

        public CheckpointStatus(long checkpointId)
        {
            CheckpointId = checkpointId;
            IsCompleted = false;
            CompletionTime = null;
        }

        [JsonConstructor]
        public CheckpointStatus(long checkpointId, bool isCompleted, DateTime? completionTime)
        {
            CheckpointId = checkpointId;
            IsCompleted = isCompleted;
            CompletionTime = completionTime;
        }

        public void MarkCompleted()
        {
            CompletionTime = DateTime.Now;
            IsCompleted = true;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return CheckpointId;
            yield return IsCompleted;
            yield return CompletionTime;
        }
    }
}
