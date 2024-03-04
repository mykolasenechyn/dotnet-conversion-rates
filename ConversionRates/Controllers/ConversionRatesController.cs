using ConversionRates.Models;
using ConversionRates.Services.ConversionData;
using Microsoft.AspNetCore.Mvc;

namespace ConversionRates.Controllers
{

  [ApiController]
  [Route("api/pricing")]
  public class ConversionRatesController : ControllerBase
  {
    private readonly IConversionDataService _conversionService;

    public ConversionRatesController(IConversionDataService conversionService)
    {
      _conversionService = conversionService;
    }

    [HttpGet("convert/{gbp}")]
    public async Task<IActionResult> ConvertRate(string gbp)
    {
      var data = await _conversionService.GetConversionData();

      if (data == null)
      {
        return NoContent();
      }


      if (decimal.TryParse(gbp, out decimal user_amount))
      {
        if (data.Rates.TryGetValue("EUR", out decimal euro_rate))
        {
          decimal conversion = user_amount * euro_rate;

          return Ok(conversion);
        }
      }

      return NoContent();
    }
  }
}