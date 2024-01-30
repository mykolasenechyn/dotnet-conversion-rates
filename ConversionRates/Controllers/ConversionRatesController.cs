using Microsoft.AspNetCore.Mvc;

namespace ConversionRates.Controllers
{

  [ApiController]
  [Route("api")]
  public class ConversionRatesController : ControllerBase
  {
    [HttpGet("rates")]
    public JsonResult GetRates()
    {
      return new JsonResult(
        new List<object>{
          new { id = 1, Currency = "GB" }
        });
    }
  }
}