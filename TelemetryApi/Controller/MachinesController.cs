using TelemetryApi.Data;
using TelemetryApi.DTO;
using TelemetryApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TelemetryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachinesController : ControllerBase
    {
        private readonly VendingDbContext _context;

        public MachinesController(VendingDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<MachineStateDto>> GetMachines()
        {
            
            return await _context.MachineState
        .Select(t => new MachineStateDto
        {
            MachineId = t.MachineId,
            TemperatureC = t.TemperatureC ?? 0,
            Status = t.Status,
            LastErrorCode = t.LastErrorCode,
            HasAlert = (t.Status != "OK") || (t.TemperatureC ?? 0) > 28
        })
        .ToListAsync();
        }
    }
}
