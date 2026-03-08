using TelemetryApi.DTO;
using TelemetryApi.Data;
using TelemetryApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TelemetryApi.Services
{
    public class TelemetryService
    {
        private readonly VendingDbContext _context;

        public TelemetryService(VendingDbContext context)
        {
            _context = context;
        }

        public async Task ProcessTelemetryAsync(List<TelemetryDto> telemetryList)
        {
            foreach (var dto in telemetryList)
            {
                var machine = await _context.MachineState
                    .FirstOrDefaultAsync(m => m.MachineId == dto.MachineId);

                if (machine == null)
                {
                    machine = new MachineState { MachineId = dto.MachineId };
                    _context.MachineState.Add(machine);
                }

                machine.TemperatureC = dto.TemperatureC;
                machine.Status = dto.Status;
                machine.LastErrorCode = dto.LastErrorCode;
                machine.TsUtc = dto.TsUtc;

                var snapshot = new Telemetry
                {
                    MachineId = dto.MachineId,
                    TemperatureC = dto.TemperatureC,
                    Status = dto.Status,
                    LastErrorCode = dto.LastErrorCode,
                    TsUtc = dto.TsUtc
                };

                _context.Telemetry.Add(snapshot);
            }

            await _context.SaveChangesAsync();
        }
        public async Task ClearDatabaseAsync()
        {
            _context.MachineState.RemoveRange(_context.MachineState);
            _context.Telemetry.RemoveRange(_context.Telemetry);
            await _context.SaveChangesAsync();
        }
    }
}

