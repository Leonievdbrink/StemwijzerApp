using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using StemwijzerApp.Models;
using StemwijzerApp.Services.Interfaces;

namespace StemwijzerApp.Services.Api
{
    public class ApiStellingService : IStellingService
    {
        private readonly HttpClient _http;

        private static readonly JsonSerializerOptions _options = new()
        {
            PropertyNameCaseInsensitive = true,
            // PDO geeft getallen vaak als strings terug ("id":"1")
            NumberHandling = JsonNumberHandling.AllowReadingFromString
        };

        public ApiStellingService(HttpClient http)
        {
            _http = http;
        }

        //haalt de stellingen op van de api in een lijst en geeft ze terug, als er geen stellingen zijn dan geeft hij een lege lijst terug
        public async Task<List<Stelling>> GetStellingenAsync()
        {
            var result = await _http.GetFromJsonAsync<List<Stelling>>("stellingen", _options);
            return result ?? new List<Stelling>();
        }
    }
}