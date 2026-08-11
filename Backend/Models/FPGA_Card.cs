namespace Backend.Models;

public class FPGA_Card
{
    public int Id { get; set; }
    public string Model { get; set; }
    public string Family { get; set; }
    public string FormFactor { get; set; }
    public string Interface { get; set; }
    public int MemoryGB { get; set; }
    public string MemoryType { get; set; }
    public int ThroughputGbps { get; set; }
    public string Purpose { get; set; }
    public string TypicalUseCase { get; set; }
}