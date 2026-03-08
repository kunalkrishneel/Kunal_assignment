using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TelemetryApi.DTO;
using TelemetryApi.Models;

namespace TelemetryApi.Data
{
    public class VendingDbContext : DbContext
    {
        public VendingDbContext (DbContextOptions<VendingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Telemetry> Telemetry { get; set; } = default!;
        public DbSet<MachineState> MachineState { get; set; } = default!;
    }
}
