using ConversionRates.Models;

namespace ConversionRates.Services.ConversionData;

public class ConversionData : IConversionDataService
{
  private readonly string URL = "https://trainlinerecruitment.github.io/exchangerates/api/latest/GBP.json";
  private readonly HttpClient _httpClient = new();
  public async Task<ConversionRateResponse?> FetchDataAsync(string url)
  {
    try
    {
      var response = await _httpClient.GetAsync(url);

      response.EnsureSuccessStatusCode();

      return await response.Content.ReadFromJsonAsync<ConversionRateResponse>();
    } catch (HttpRequestException error)
    {
      Console.WriteLine($"Error: {error.Message}");
      return null;
    }
  }

  public void Dispose()
  {
    _httpClient.Dispose();
  }

  public async Task<ConversionRateResponse?> GetConversionData()
  {
    var responseData = await FetchDataAsync(URL);

    return responseData;
  }
}