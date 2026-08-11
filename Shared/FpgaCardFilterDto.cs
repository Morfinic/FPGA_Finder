namespace Shared;

public class FpgaCardFilterDto
{
    public string? Family { get; set; }
    public string? Purpose { get; set; }
    public int? MinThroughputGbps  { get; set; }
    public int? MaxThroughputGbps { get; set; }
}