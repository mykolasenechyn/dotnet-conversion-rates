namespace ConversionRates
{
    public class HttpDataFetcher : IDisposable
    {
        private readonly HttpClient _httpClient = new();

        public async Task<string?> FetchDataAsync(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);
                
                response.EnsureSuccessStatusCode();
                
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException error)
            {
                Console.WriteLine($"Error: {error.Message}");
                return null;
            }
        }
        
        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}