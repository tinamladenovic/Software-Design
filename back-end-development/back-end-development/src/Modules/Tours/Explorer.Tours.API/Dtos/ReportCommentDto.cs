using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos
{
    public class ReportCommentDto
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        public string CommentText { get; set; }
    }
}
