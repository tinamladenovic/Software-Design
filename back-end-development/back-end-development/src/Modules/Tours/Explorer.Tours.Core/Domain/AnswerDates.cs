using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain
{
    public class AnswerDates : Entity
    {
        public int userId { get; set; }
        public DateTime lastAnswerDate { get; set; }

        public AnswerDates() { }

        public AnswerDates(int userId, DateTime lastAnswerDate)
        {
            this.userId = userId;
            this.lastAnswerDate = lastAnswerDate;
        }
    }
}
