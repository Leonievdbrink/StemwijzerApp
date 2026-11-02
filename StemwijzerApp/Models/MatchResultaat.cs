using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace StemwijzerApp.Models
{
    public class Positie
    {
        [JsonPropertyName("x")] public double X { get; set; }
        [JsonPropertyName("y")] public double Y { get; set; }
    }

    public class MatchResultaat
    {
        [JsonPropertyName("partij_id")] public int PartijId { get; set; }
        [JsonPropertyName("naam")] public string VolleNaam { get; set; } = "";
        [JsonPropertyName("afkorting")] public string? Afkorting { get; set; }
        [JsonPropertyName("percentage")] public double Percentage { get; set; }
        [JsonPropertyName("rang")] public int Rang { get; set; }
        [JsonPropertyName("x")] public double X { get; set; }
        [JsonPropertyName("y")] public double Y { get; set; }

        //bereken de naam die getoond moet worden, afhankelijk van of er een afkorting is of niet
        [JsonIgnore] public string Naam => string.IsNullOrWhiteSpace(Afkorting) ? VolleNaam : Afkorting!;
        //bereken de fractie van het percentage
        [JsonIgnore] public double Fractie => Percentage / 100.0;
        //bereken de tekst die getoond moet worden voor het percentage
        [JsonIgnore] public string PercentageTekst => $"{Percentage:0}%";
    }

    public class ResultaatResponse
    {
        [JsonPropertyName("gebruiker")] public Positie Gebruiker { get; set; } = new();
        [JsonPropertyName("partijen")] public List<MatchResultaat> Partijen { get; set; } = new();
    }
}
