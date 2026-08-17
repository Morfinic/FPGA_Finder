using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class FPGA_Card
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string Model { get; set; } = string.Empty;
    [MaxLength(100)]
    public string Family { get; set; } = string.Empty;
    [MaxLength(100)]
    public string FormFactor { get; set; } = string.Empty;
    [MaxLength(100)]
    public string Interface { get; set; } = string.Empty;
    public int MemoryGB { get; set; }
    [MaxLength(100)]
    public string MemoryType { get; set; } = string.Empty;
    public int ThroughputGbps { get; set; }
    [MaxLength(100)]
    public string Purpose { get; set; } = string.Empty;
    [MaxLength(255)]
    public string TypicalUseCase { get; set; } = string.Empty;
}