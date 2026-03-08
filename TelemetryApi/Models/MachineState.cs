using System.ComponentModel.DataAnnotations;

namespace TelemetryApi.Models
{
    public class MachineState
    {
        [Key]
        public required string MachineId { get; set; }

        public double? TemperatureC { get; set; }

        public string? Status { get; set; }

        public string? LastErrorCode { get; set; }

        public DateTime? TsUtc { get; set; }
    }
}
