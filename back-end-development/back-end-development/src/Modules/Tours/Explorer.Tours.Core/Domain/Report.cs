using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain
{
    public enum Priority
    {
        Low,
        Medium,
        High,
    }

    public class Report : Entity
    {
        public string Category { get; set; }
        public Priority Priority { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }

        public Report(string category, Priority priority, string description, DateTime dateCreated)
        {
            if (string.IsNullOrWhiteSpace(category)) throw new ArgumentNullException("Invalid category");
            Category = category;
            Priority = priority;
            Description = description;
            DateCreated = dateCreated;
        }
    }
}
