using Microsoft.AspNetCore.Mvc;
using CryptoTracker.Price.Application.Interfaces;

namespace CryptoTracker.Price.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PriceController : ControllerBase
{
    private readonly IPriceService _priceService;

    public PriceController(IPriceService priceService)
    {
        _priceService = priceService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPrices([FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
    {
        if (fromDate > toDate)
            return BadRequest("Start date must be before end date.");

        var prices = await _priceService.GetPricesAsync(fromDate, toDate);
        return Ok(prices);
    }
}
