using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos.Execution;
public enum TourExecutionStatus { Active, Completed, Abandoned }
public class TourExecutionDto
{
    public long Id { get; set; }
    public long TourId { get; set; }
    public bool IsComposite{ get; set; }
    public long TouristId { get; set; }
    public DateTime LastActivity { get; set; }
    public TourExecutionStatus Status { get; set; }
    public List<CheckpointStatusDto> CheckpointStatuses { get; set; }
    public double CoveredDistance { get; set; }

    public TourExecutionDto()
    {
    }

    public TourExecutionDto(long touristId, long tourId, DateTime lastActivity, TourExecutionStatus status, List<CheckpointStatusDto> checkpointStatuses, double distance, bool isComposite = false)
    {
        TouristId = touristId;
        TourId = tourId;
        LastActivity = lastActivity;
        Status = status;
        CheckpointStatuses = checkpointStatuses;
        CoveredDistance = distance;
        IsComposite = isComposite;
    }
}
