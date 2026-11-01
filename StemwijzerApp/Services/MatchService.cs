using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using StemwijzerApp.Models;
using StemwijzerApp.Services.Interfaces;

namespace StemwijzerApp.Services
{
    public class MatchService : IMatchService
    {
        private readonly HttpClient _http;

        public MatchService(HttpClient http) => _http = http;

        //roept de functie aan voor de berekening van de resultaten op basis van de antwoorden van de gebruiker
        public async Task<ResultaatResponse> BerekenAsync(IReadOnlyList<Antwoord> antwoorden)
        {
            //stuurt de antwoorden naar de api en ontvangt het resultaat
            var response = await _http.PostAsJsonAsync("resultaat", new { antwoorden });
            response.EnsureSuccessStatusCode();
            // haalt het resultaat op en stuurt t terug
            return await response.Content.ReadFromJsonAsync<ResultaatResponse>() ?? new ResultaatResponse();
        }
    }
}
