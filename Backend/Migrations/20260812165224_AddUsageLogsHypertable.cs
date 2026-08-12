using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddUsageLogsHypertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsageLogs",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "integer", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UtilizationPercent = table.Column<double>(type: "double precision", nullable: false),
                    MeasuredThroughputGbps = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsageLogs", x => new { x.Timestamp, x.CardId });
                });
            
            migrationBuilder.Sql("CREATE EXTENSION IF NOT EXISTS timescaledb;");
            migrationBuilder.Sql("SELECT create_hypertable('\"UsageLogs\"', 'Timestamp', if_not_exists => TRUE);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsageLogs");
        }
    }
}
