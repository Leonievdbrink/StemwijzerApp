using System.Text.Json.Serialization;

namespace StemwijzerApp.Models
{
    public class Stelling
    {
        public int Id { get; set; }

        [JsonPropertyName("categorieId")]
        public int CategorieId { get; set; }

        [JsonPropertyName("categorieNaam")]
        public string? CategorieNaam { get; set; }

        public string Tekst { get; set; } = "";
        public string Status { get; set; } = "";
    }
}