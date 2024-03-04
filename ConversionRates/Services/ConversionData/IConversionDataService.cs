using ConversionRates.Models;

namespace ConversionRates.Services.ConversionData;

public interface IConversionDataService
{
  Task<ConversionRateResponse?> GetConversionData();
}