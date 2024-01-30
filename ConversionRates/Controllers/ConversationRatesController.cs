using Microsoft.AspNetCore.Mvc;

namespace ConversionRates.Controllers
{

  [ApiController]
  [Route("api/rates")]
  public class ConversationRatesController : ControllerBase
  {
    [HttpGet("api/rates")]
    public JsonResult GetRates()
    {
      return new JsonResult(
        new List<object>{
          new { id = 1, Currency = "GB" }
        });
    }
  }
}