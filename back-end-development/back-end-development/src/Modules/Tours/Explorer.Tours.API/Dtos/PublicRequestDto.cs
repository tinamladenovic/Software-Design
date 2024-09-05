using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos
{
    public class PublicRequestDto
    {
        public RequestStatusDto Status { get; set; }
        public string? Comment { get; set; }

        public PublicRequestDto(RequestStatusDto status, string? comment)
        {
            Status = status;
            Comment = comment;
        }
    }

    public enum RequestStatusDto
    {
        Accepted,
        Rejected,
        Pending
    }
}
