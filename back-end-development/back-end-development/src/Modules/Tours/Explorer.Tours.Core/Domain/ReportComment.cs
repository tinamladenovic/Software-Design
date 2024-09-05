using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain;

public class ReportComment : Entity
{
    public int ReportId { get; set; }
    public string CommentText { get; set; }

    public ReportComment(int reportId, string commentText)
    {
        ReportId = reportId;
        CommentText = commentText;
    }
}
