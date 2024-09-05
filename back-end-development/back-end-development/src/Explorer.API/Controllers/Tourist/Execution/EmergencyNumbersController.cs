using Explorer.Tours.API.Public.TourExecution;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Explorer.API.Controllers.Tourist.Execution
{

    [ApiController]
    [Route("api/emergencynumbers")]
    public class EmergencyNumbersController : ControllerBase
    {
        private readonly IEmergencyNumbersService _emergencyNumbersService;

        public EmergencyNumbersController(IEmergencyNumbersService emergencyNumbersService)
        {
            _emergencyNumbersService = emergencyNumbersService;
        }


        [HttpGet("numbers")]
        public async Task<IActionResult> GetEmergencyNumbers([FromQuery] string code)
        {
            try
            {
                var result = await _emergencyNumbersService.GetEmergencyNumbers(code);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
