namespace Frontend.Models;

public class FpgaCardSummary
{
    public int Id { get; set; }
    public string? Model { get; set; }
    public string? Family { get; set; }
    public string? TypicalUseCase { get; set; }
    public int MemoryGB { get; set; }
    public int ThroughputGbps { get; set; }
}