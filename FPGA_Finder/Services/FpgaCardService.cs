using FPGA_Finder.Data;
using FPGA_Finder.Models;
using Microsoft.EntityFrameworkCore;

namespace FPGA_Finder.Services;

public class FpgaCardService(AppDbContext context) : IFpgaCardService
{
    public async Task<List<FPGA_Card>> GetAllCardsAsync() =>
        await context.FPGA_Cards.ToListAsync();
}