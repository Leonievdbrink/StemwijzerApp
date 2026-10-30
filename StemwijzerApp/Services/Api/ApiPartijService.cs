using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using StemwijzerApp.Models;
using StemwijzerApp.Services.Interfaces;

namespace StemwijzerApp.Services.Api
{
    public class ApiPartijService : IPartijService
    {
        private readonly HttpClient _http;

        private static readonly JsonSerializerOptions _options = new()
        {
            PropertyNameCaseInsensitive = true,
            NumberHandling = JsonNumberHandling.AllowReadingFromString
        };

        public ApiPartijService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Partij>> GetPartijenAsync()
        {
            var result = await _http.GetFromJsonAsync<List<Partij>>("partijen", _options)
                         ?? new List<Partij>();

            for (int i = 0; i < result.Count; i++)
                result[i].Nummer = i + 1;

            return result;
        }
    }
}