using ConversionRates.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConversionRates.Controllers
{

  [ApiController]
  [Route("api")]
  public class ConversionRatesController : ControllerBase
  {
    [HttpGet("rates")]
    public async Task<ActionResult<IEnumerable<ConversionRate>>?> GetRates()
    {
      const string url = "https://trainlinerecruitment.github.io/exchangerates/api/latest/GBP.json";

      using var dataFetcher = new HttpDataFetcher();
      var responseData = await dataFetcher.FetchDataAsync(url);

      if (responseData != null)
      {
        Console.WriteLine($"Fetched data: {responseData}");
        return Ok(responseData);
      }
      else
      {
        Console.WriteLine("Failed to fetch data.");
        return null;
      }
    }
  }
}