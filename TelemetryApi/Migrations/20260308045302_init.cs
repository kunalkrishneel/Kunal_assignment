using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelemetryApi.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MachineState",
                columns: table => new
                {
                    MachineId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TemperatureC = table.Column<double>(type: "float", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastErrorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TsUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineState", x => x.MachineId);
                });

            migrationBuilder.CreateTable(
                name: "Telemetry",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemperatureC = table.Column<double>(type: "float", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastErrorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TsUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telemetry", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MachineState");

            migrationBuilder.DropTable(
                name: "Telemetry");
        }
    }
}
