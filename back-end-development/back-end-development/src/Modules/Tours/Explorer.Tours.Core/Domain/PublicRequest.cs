using System.Text.Json.Serialization;
using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Tours.Core.Domain;

public enum CheckpointRequestStatus
{
    Accepted,
    Rejected,
    Pending
}

public class PublicRequest : ValueObject
{
    public CheckpointRequestStatus Status { get; set; }
    public string? Comment { get; set; }

    [JsonConstructor]
    public PublicRequest(CheckpointRequestStatus status, string? comment)
    {
        Status = status;
        Comment = comment;
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Status;
        yield return Comment;
    }
}