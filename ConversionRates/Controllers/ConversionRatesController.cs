using ConversionRates.Models;
using ConversionRates.Services.ConversionData;
using Microsoft.AspNetCore.Mvc;

namespace ConversionRates.Controllers
{

  [ApiController]
  [Route("api")]
  public class ConversionRatesController : ControllerBase
  {
    private readonly IConversionDataService _conversionService;

    public ConversionRatesController(IConversionDataService conversionService)
    {
      _conversionService = conversionService;
    }

    [HttpGet("rates")]
    public async Task<IActionResult> GetRates()
    {
      var data = await _conversionService.GetConversionData();
      return Ok(data);
    }
  }
}