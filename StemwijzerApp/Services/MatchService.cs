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

        public async Task<ResultaatResponse> BerekenAsync(IReadOnlyList<Antwoord> antwoorden)
        {
            var response = await _http.PostAsJsonAsync("resultaat", new { antwoorden });
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ResultaatResponse>() ?? new ResultaatResponse();
        }
    }
}
