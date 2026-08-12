using System.Text.Json;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

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

        if (!await context.UsageLogs.AnyAsync())
        {
            try
            {
                var seedSql = """
                                  INSERT INTO "UsageLogs" ("Timestamp", "CardId", "UtilizationPercent", "MeasuredThroughputGbps")
                                  SELECT 
                                      g.ts AS "Timestamp",
                                      c."Id" AS "CardId",
                                      ROUND((30 + random() * 65)::numeric, 2)::double precision AS "UtilizationPercent",
                                      ROUND((10 + random() * 90)::numeric, 2)::double precision AS "MeasuredThroughputGbps"
                                  FROM generate_series(
                                      NOW() - INTERVAL '7 days', 
                                      NOW(), 
                                      INTERVAL '1 hour'
                                  ) AS g(ts)
                                  CROSS JOIN "FPGA_Cards" as c;
                              """;
            
                await context.Database.ExecuteSqlRawAsync(seedSql);
            } catch  (Exception e)
            {
                Console.WriteLine($"[Seed Error] {e.Message}");
                if (e.InnerException != null)
                    Console.WriteLine($"[Seed Inner Error] {e.InnerException.Message}");
            }
        }
    }
}