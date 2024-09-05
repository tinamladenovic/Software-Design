using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.Domain
{
    public class Questionnaire : Entity
    {
        public string Question { get; set; }
        public string Answer { get; set; }


        public Questionnaire()
        {

        }

        public Questionnaire(string question, string answer)
        {
            Question = question;
            Answer = answer;
        }


    }
}
