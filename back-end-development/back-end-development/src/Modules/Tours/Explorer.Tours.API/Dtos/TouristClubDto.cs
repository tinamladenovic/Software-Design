using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos;

public class TouristClubDto
{
    public int Id { get; set; }
    public string ClubName { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public int OwnerId { get; set; }
}
