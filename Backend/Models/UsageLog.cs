using Microsoft.EntityFrameworkCore;

namespace Backend.Models;

[PrimaryKey(nameof(Timestamp), nameof(CardId))]
public class UsageLog
{
    public int CardId { get; set; }
    public DateTime Timestamp { get; set; }
    public double UtilizationPercent { get; set; }
    public double MeasuredThroughputGbps { get; set; }
}