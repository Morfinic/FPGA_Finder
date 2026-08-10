using FPGA_Finder.Models;

namespace FPGA_Finder.Services;

public interface IFpgaCardService
{
    Task<List<FPGA_Card>> GetAllCardsAsync();
}