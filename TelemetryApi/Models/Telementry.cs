using System.ComponentModel.DataAnnotations;

namespace TelemetryApi.Models
{
    public class Telemetry
    {
        [Key]
        public long Id { get; set; }

        public required string MachineId { get; set; }

        public double? TemperatureC { get; set; }

        public string? Status { get; set; }

        public string? LastErrorCode { get; set; }

        public DateTime? TsUtc { get; set; }
    }
}
