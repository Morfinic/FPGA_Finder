using Backend.Models;
using Shared;

namespace Backend.Services;

public interface IFpgaCardService
{
    Task<List<FPGA_Card>> GetAllCardsAsync();
    Task<FPGA_Card?> GetCardByIdAsync(int cardId);
    Task<List<FPGA_Card>> SearchCards(FpgaCardFilter filter);
}