


using DevCodeChallenge.Entities;
using Newtonsoft.Json;

namespace DevCodeChallenge.Services
{
    public class NasaService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public NasaService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["NasaApiKey"];
        }

        public async Task<NasaApod> GetApodByDateAsync(DateTime date) 
        {
            string url = $"https://api.nasa.gov/planetary/apod?api_key={_apiKey}&date={date:yyyy-MM-dd}";
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<NasaApod>(jsonString);

        }
    }
}
