using System.ComponentModel.DataAnnotations;

namespace TelemetryApi.DTO
{
    public class TelemetryDto
    {
   
        public string MachineId { get; set; }
        public double TemperatureC { get; set; }
        public string? Status { get; set; }
        public string? LastErrorCode { get; set; }
        public DateTime TsUtc { get; set; }
    }
}
