using StemwijzerApp.Models;

namespace StemwijzerApp.Services
{
    public class AntwoordenService
    {
        public List<Antwoord> Antwoorden { get; } = new();

        public void Opslaan(int stellingId, string keuze)
        {
            Antwoorden.RemoveAll(a => a.StellingId == stellingId);
            Antwoorden.Add(new Antwoord { StellingId = stellingId, Keuze = keuze });
        }

        public void Wis() => Antwoorden.Clear();
    }
}