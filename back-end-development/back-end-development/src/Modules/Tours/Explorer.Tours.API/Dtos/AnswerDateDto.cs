using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos
{
    public class AnswerDateDto
    {
        public long Id { get; set; }
        public int userId { get; set; }
        public DateTime lastAnswerDate { get; set; }

    }
}
