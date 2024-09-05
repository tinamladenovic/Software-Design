using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos
{
    public class SingleTourStatisticDto
    {
        public int Sales { get; set; }
        public int Executions { get; set; }
        public int Finishes { get; set; }
        public Dictionary<string,double> CheckpointPercentages { get; set; }

        public SingleTourStatisticDto( int sales,int executions, int finishes, Dictionary<string,double> checkpointPercentages)
        {
            Sales = sales;
            Executions = executions;
            Finishes = finishes;
            CheckpointPercentages = checkpointPercentages;
        }
    }
}
