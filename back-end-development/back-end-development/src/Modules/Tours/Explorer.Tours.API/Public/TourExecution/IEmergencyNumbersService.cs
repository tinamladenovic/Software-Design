using Explorer.Tours.API.Dtos.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Public.TourExecution
{
    public interface IEmergencyNumbersService
    {
        public Task<EmergencyNumbersResponse> GetEmergencyNumbers(string code);
    }
}
