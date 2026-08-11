using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FpgaCardController(IFpgaCardService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<FPGA_Card>>> GetCards() =>
        Ok(await service.GetAllCardsAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<FPGA_Card>> GetCard(int id)
    {
        var card = await service.GetCardByIdAsync(id);
        return card is null ? NotFound("Card not found") : Ok(card);
    }

    [HttpGet("filter")]
    public async Task<ActionResult<List<FPGA_Card>>> SearchCards([FromQuery] FpgaCardFilterDto filter) =>
        Ok(await service.SearchCards(filter));
}