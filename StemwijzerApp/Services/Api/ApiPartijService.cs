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

        //opties voor voor de json zodat hoofdletters niet uitmaken en dat nummers vanuit strings ook leesbaar zijn
        private static readonly JsonSerializerOptions _options = new()
        {
            PropertyNameCaseInsensitive = true,
            NumberHandling = JsonNumberHandling.AllowReadingFromString
        };

        private string BuildImageUrl(string imagePath)
        {
            var fileName = Path.GetFileName(
                imagePath.Replace('\\', '/'));

            var imageUri = new Uri(
                _http.BaseAddress!,
                $"../UploadedImages/{Uri.EscapeDataString(fileName)}");

            return imageUri.ToString();
        }

        // constructor
        public ApiPartijService(HttpClient http)
        {
            _http = http;
        }

        // haalt de partijen op van de api en zet het nummer van de partij in de lijst
        public async Task<List<Partij>> GetPartijenAsync()
        {
            var result = await _http.GetFromJsonAsync<List<Partij>>(
                "partijen",
                _options) ?? new List<Partij>();

            for (int i = 0; i < result.Count; i++)
            {
                result[i].Nummer = i + 1;

                if (!string.IsNullOrWhiteSpace(result[i].LogoUrl))
                {
                    result[i].LogoUrl =
                        BuildImageUrl(result[i].LogoUrl);
                }
            }

            return result;
        }
    }
}