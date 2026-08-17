using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Backend.Services;

public class FpgaCardService(AppDbContext context) : IFpgaCardService
{
    public async Task<List<FPGA_Card>> GetAllCardsAsync() =>
        await context.FPGA_Cards.ToListAsync();

    public Task<FPGA_Card?> GetCardByIdAsync(int cardId)
    {
        var result = context.FPGA_Cards.FirstOrDefault(c => c.Id == cardId);
        return Task.FromResult(result);
    }

    public async Task<List<FPGA_Card>> SearchCards(FpgaCardFilter filter)
    {
        var query = context.FPGA_Cards.AsQueryable();
        
        if (!String.IsNullOrWhiteSpace(filter.Family))
            query = query.Where(c => c.Family.ToLower().Contains(filter.Family.Trim().ToLower()));
        if (!String.IsNullOrWhiteSpace(filter.Purpose))
            query = query.Where(c => c.Purpose.ToLower().Contains(filter.Purpose.Trim().ToLower()));
        if (filter.MinThroughputGbps > 0)
            query = query.Where(c => c.ThroughputGbps >= filter.MinThroughputGbps);
        if (filter.MaxThroughputGbps > 0)
            query = query.Where(c => c.ThroughputGbps <= filter.MaxThroughputGbps);
        
        return await query.ToListAsync();
    }

    public async Task<FilterOptions> GetFilterOptionsAsync()
    {
        var cards = await context.FPGA_Cards.ToListAsync();
        return new FilterOptions
        {
            Families = cards.Select(c => c.Family).Distinct().OrderBy(f => f).ToList(),
            Purposes = cards.Select(c => c.Purpose).Distinct().OrderBy(p => p).ToList()
        };
    }
}