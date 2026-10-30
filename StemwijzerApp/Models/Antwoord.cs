using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace StemwijzerApp.Models
{
    public class Antwoord
    {
        [JsonPropertyName("stelling_id")] public int StellingId { get; set; }
        [JsonPropertyName("keuze")] public string Keuze { get; set; } = "geen mening";
    }
}
