namespace ConversionRates.Models;

public class ConversionRateResponse
{
  public string Base { get; set; } = string.Empty;
  public DateOnly Date { get; set; }
  public TimeOnly TimeLastUpdated { get; set; }
  public Dictionary<string, decimal>? Rates { get; set; }
}