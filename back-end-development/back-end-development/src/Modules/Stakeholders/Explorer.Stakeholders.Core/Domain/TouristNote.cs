using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Stakeholders.Core.Domain;

public class TouristNote : Entity
{
    public long UserId { get; init; }
    public string Note { get; init; }

    public TouristNote(long userId, string note)
    {
        UserId = userId;
        Note = note;
    }
}
