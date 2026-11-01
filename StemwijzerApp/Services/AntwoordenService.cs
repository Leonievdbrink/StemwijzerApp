using StemwijzerApp.Models;

namespace StemwijzerApp.Services
{
    public class AntwoordenService
    {
        //lijst met antwoorden van de gebruiker
        public List<Antwoord> Antwoorden { get; } = new();

        //functie om een antwoord op te slaan in de lijst van antwoorden
        public void Opslaan(int stellingId, string keuze)
        {
            Antwoorden.RemoveAll(a => a.StellingId == stellingId);
            Antwoorden.Add(new Antwoord { StellingId = stellingId, Keuze = keuze });
        }
        //functie om de lijst van antwoorden te wissen

        public void Wis() => Antwoorden.Clear();
    }
}