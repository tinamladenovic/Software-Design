using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Tours.Core.Domain.ValueObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain.TourExecutions;

public enum TourExecutionStatus { Active, Completed, Abandoned }
public class TourExecution : Entity
{
    public long TouristId { get; init; }
    public long TourId { get; init; }
    public bool IsComposite{ get; init; }
    public DateTime LastActivity { get; private set; }
    public TourExecutionStatus Status { get; private set; }
    public List<CheckpointStatus> CheckpointStatuses { get; private set; }
    public double CoveredDistance { get; private set; }

    public TourExecution() { }
    public TourExecution(long touristId, long tourId, List<long> checkpointIds, bool isComposite = false)
    {
        TouristId = touristId;
        TourId = tourId;
        LastActivity = DateTime.Now.ToUniversalTime();
        Status = TourExecutionStatus.Active;
        CheckpointStatuses = new List<CheckpointStatus>();
        checkpointIds.ForEach(id => CheckpointStatuses.Add(new CheckpointStatus(id)));
        IsComposite = isComposite;
    }
    
    public void Abandon()
    {
        if (Status == TourExecutionStatus.Active)
        {
            Status = TourExecutionStatus.Abandoned;
            LastActivity = DateTime.Now.ToUniversalTime();
        }
    }

    public bool IsCompleted()
    {
        if (CheckpointStatuses.Any(c => !c.IsCompleted))
            return false;
        Status = TourExecutionStatus.Completed;
        return true;
    }

    public void UpdateDistance(double distance)
    {
        if (Status == TourExecutionStatus.Active)
        {
            CoveredDistance = distance;
        }
    }   

    public void UpdateLastActivity()
    {
        if (Status == TourExecutionStatus.Active)
        {
            LastActivity = DateTime.Now.ToUniversalTime();
        }
    }

    public void MarkCompleted(long checkpointId)
    {
        if (Status == TourExecutionStatus.Active)
        {
            CheckpointStatuses.Find(c => c.CheckpointId == checkpointId).MarkCompleted();
            IsCompleted();
        }
    }

    public List<long> GetCompletedCheckpointIds()
    {
        var ids = new List<long>();
        CheckpointStatuses.FindAll(c => c.IsCompleted).ForEach(compC =>  ids.Add(compC.CheckpointId));
        return ids;
    }
}
