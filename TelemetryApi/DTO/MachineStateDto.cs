
using System.ComponentModel.DataAnnotations;

namespace TelemetryApi.DTO
{
    public class MachineStateDto
    {
    
        public string MachineId { get; set; }

        public double TemperatureC { get; set; }
        public string? Status { get; set; }
        public string? LastErrorCode { get; set; }
        public bool HasAlert { get; set; }
    }
}
