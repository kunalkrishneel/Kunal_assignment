using TelemetryApi.DTO;
using TelemetryApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TelemetryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelemetryController : ControllerBase
    {
        private readonly TelemetryService _service;

        public TelemetryController(TelemetryService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> PostTelemetry([FromBody] List<TelemetryDto> telemetry)
        {
            await _service.ProcessTelemetryAsync(telemetry);

            return Ok();
        }
        [HttpPost("clear")]
        public async Task<IActionResult> ClearTelemetry()
        {
            await _service.ClearDatabaseAsync();

            return Ok();
        }
    }
}
