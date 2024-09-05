using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos.Execution
{
    public class EmergencyNumbersResponse
    {
        public string Disclaimer { get; set; }
        public string Error { get; set; }
        public EmergencyNumbersData Data { get; set; }
    }

    public class EmergencyNumbersData
    {
        public EmergencyNumbersCountry Country { get; set; }
        public EmergencyNumbersService Ambulance { get; set; }
        public EmergencyNumbersService Fire { get; set; }
        public EmergencyNumbersService Police { get; set; }
        public EmergencyNumbersService Dispatch { get; set; }
        public bool Member112 { get; set; }
        public bool LocalOnly { get; set; }
        public bool NoData { get; set; }
    }

    public class EmergencyNumbersCountry
    {
        public string Name { get; set; }
        public string ISOCode { get; set; }
        public string ISONumeric { get; set; }
    }

    public class EmergencyNumbersService
    {
        public List<string> All { get; set; }
        public string Gsm { get; set; }
        public string Fixed { get; set; }
    }

}
