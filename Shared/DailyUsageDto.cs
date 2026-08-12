namespace Shared;

public class DailyUsageDto
{
    public DateTime Date { get; set; }
    public int CardId { get; set; }
    public double AvgUtilizationPercent { get; set; }
    public double AvgThroughputPercent { get; set; }
}