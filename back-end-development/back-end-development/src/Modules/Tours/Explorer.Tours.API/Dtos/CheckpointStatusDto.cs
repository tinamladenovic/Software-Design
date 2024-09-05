using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos;

public class CheckpointStatusDto
{
    public long CheckpointId { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime? CompletionTime { get; set; }

    public CheckpointStatusDto(long checkpointId, bool isCompleted, DateTime? completionTime)
    {
        CheckpointId = checkpointId;
        IsCompleted = isCompleted;
        CompletionTime = completionTime;
    }

    public CheckpointStatusDto() { }
}
