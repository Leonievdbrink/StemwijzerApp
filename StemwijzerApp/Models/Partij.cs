using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace StemwijzerApp.Models
{
    public class Partij
    {
        public int Id { get; set; }
        public string Naam { get; set; } = "";
        public string? Afkorting { get; set; }
        public string? Beschrijving { get; set; }
        public string? Voorzitter { get; set; }

        [JsonPropertyName("logo_url")]
        public string? LogoUrl { get; set; }

        [JsonIgnore]
        public int Nummer { get; set; }

        [JsonIgnore]
        public string Kort => string.IsNullOrWhiteSpace(Afkorting) ? Naam : Afkorting!;
    }
}