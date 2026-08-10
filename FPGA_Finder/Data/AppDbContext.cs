using FPGA_Finder.Models;
using Microsoft.EntityFrameworkCore;

namespace FPGA_Finder.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public required DbSet<FPGA_Card> FPGA_Cards { get; set; }
}