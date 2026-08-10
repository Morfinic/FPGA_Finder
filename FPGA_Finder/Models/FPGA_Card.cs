using System.Text.Json.Serialization;

namespace FPGA_Finder.Models;

public class FPGA_Card
{
    public int Id { get; set; }
    
    [JsonPropertyName("model")]
    public string Model { get; set; }
    
    [JsonPropertyName("family")]
    public string Family { get; set; }
    
    [JsonPropertyName("formFactor")]
    public string formFactor { get; set; }
    
    [JsonPropertyName("interface")]
    public string Interface { get; set; }
    
    [JsonPropertyName("memoryGB")]
    public int memoryGB { get; set; }
    
    [JsonPropertyName("memoryType")]
    public string memoryType { get; set; }
    
    [JsonPropertyName("throughputGbps")]
    public int throughputGbps { get; set; }
    
    [JsonPropertyName("purpose")]
    public string Purpose { get; set; }
    
    [JsonPropertyName("typicalUseCase")]
    public string typicalUseCase { get; set; }
}