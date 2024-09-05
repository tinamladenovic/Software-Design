using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos
{
    public enum Priority
    {
        Low,
        Medium,
        High,
    }
    public class ReportDto
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public Priority Priority { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
