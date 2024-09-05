using Explorer.Tours.API.Dtos.Execution;
using Explorer.Tours.API.Public.TourExecution;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.Core.UseCases.Execution
{
    public class EmergencyNumbersService : IEmergencyNumbersService
    {
        private readonly HttpClient _httpClient;

        public EmergencyNumbersService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<EmergencyNumbersResponse> GetEmergencyNumbers(string code)
        {
            var apiUrl = $"https://emergencynumberapi.com/api/country/{code}";

            var response = await _httpClient.GetStringAsync(apiUrl);

            return JsonConvert.DeserializeObject<EmergencyNumbersResponse>(response);
        }

    }
}
