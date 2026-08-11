using System.Text.Json;
using Backend.Models;

namespace Backend.Data;

public static class DbInit
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (context.FPGA_Cards.Any())
            return;
        
        var filepath = Path.Combine(AppContext.BaseDirectory, "cards.json");

        if (!File.Exists(filepath))
        {
            Console.WriteLine($"[Seed Error] Nie znaleziono pliku: {filepath}");
            return;
        }
        
        var jsonData = await File.ReadAllTextAsync(filepath);
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var devices = JsonSerializer.Deserialize<List<FPGA_Card>>(jsonData, options);
        
        if (devices != null && devices.Any())
        {
            await context.FPGA_Cards.AddRangeAsync(devices);
            await context.SaveChangesAsync();
            Console.WriteLine($"[Seed Success] Dodano {devices.Count} kart");
        }
    }
}