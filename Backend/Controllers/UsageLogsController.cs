using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsageLogsController : ControllerBase
{
    private readonly AppDbContext _context;
    public UsageLogsController(AppDbContext context)
    {
        _context = context;
    }
    
    [HttpGet("card/{card_id}")]
    public async Task<ActionResult<List<DailyUsageDto>>> GetDailyStats(int card_id, [FromQuery] int days = 4)
    {
        var sql = """
            SELECT
                time_bucket('1 day', "Timestamp") as "DATE",
                "CardId",
                ROUND(AVG("UtilizationPercent")::numeric, 2) AS "AvgUtilizationPercent",
                ROUND(AVG("MeasuredThroughputGbps")::numeric, 2) AS "AvgThroughputPercent"
            FROM "UsageLogs"
            WHERE "CardId" = {0}
            GROUP BY "DATE", "CardId"
            ORDER BY "DATE" ASC
            LIMIT {1};
        """;

        var stats = await _context.Database.SqlQueryRaw<DailyUsageDto>(sql, card_id, days).ToListAsync();
        return Ok(stats);
    }
}