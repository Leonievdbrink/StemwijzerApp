using System.Text.Json.Serialization;

namespace StemwijzerApp.Models
{
    public class Stelling
    {
        public int Id { get; set; }

        [JsonPropertyName("categorie_id")]
        public int CategorieId { get; set; }

        public string Tekst { get; set; } = "";
        public string Status { get; set; } = "";
    }
}