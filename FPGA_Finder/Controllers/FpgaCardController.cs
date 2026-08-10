using FPGA_Finder.Models;
using FPGA_Finder.Services;
using Microsoft.AspNetCore.Mvc;

namespace FPGA_Finder.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FpgaCardController(IFpgaCardService service) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<FPGA_Card>>> GetCards() =>
        Ok(await service.GetAllCardsAsync());
}