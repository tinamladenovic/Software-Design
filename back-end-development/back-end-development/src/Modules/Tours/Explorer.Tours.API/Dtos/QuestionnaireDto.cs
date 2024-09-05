using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos
{
    public class QuestionnaireDto
    {
        public long Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

    }
}
