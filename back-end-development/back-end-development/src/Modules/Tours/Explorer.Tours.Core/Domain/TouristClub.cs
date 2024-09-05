using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Stakeholders.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain;

public class TouristClub : Entity
{
    public string ClubName { get; private set; }
    public string? Description { get; private set; }
    public string Image { get; private set; }
    public long OwnerId { get; private set; }

    public TouristClub()
    {

    }
    public TouristClub(string clubName, string? description, string image, long ownerId)
    {
        if (string.IsNullOrWhiteSpace(clubName)) throw new ArgumentException("Invalid club name.");
        ClubName = clubName;
        Description = description;
        Image = image;
        OwnerId = ownerId;
    }
}
