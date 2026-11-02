using StemwijzerApp.Models;
using StemwijzerApp.Services;
using StemwijzerApp.Services.Interfaces;

namespace StemwijzerApp;

public partial class QuestionPage : ContentPage
{
    private readonly IStellingService _stellingService;
    private readonly AntwoordenService _antwoorden;
    private List<Stelling> _stellingen = new();
    private int _index = 0;

    public QuestionPage(IStellingService stellingService, AntwoordenService antwoorden)
    {
        InitializeComponent();
        _stellingService = stellingService;
        _antwoorden = antwoorden;
    }

    protected override async void OnAppearing()
    {
        // Haalt de stellingen op wanneer de pagina verschijnt en toont de eerste stelling
        base.OnAppearing();
        //wis de oude antwoorden zodat de gebruiker opnieuw kan stemmen
        _antwoorden.Wis();

        // Haal de stellingen op van de service en toon de eerste stelling
        try
        {
            _stellingen = await _stellingService.GetStellingenAsync();
            _index = 0;
            ToonHuidigeStelling();
        }
        catch (Exception ex)
        {
            StellingArea.Text = $"De stellingen konden niet worden geladen: {ex.Message}";
        }
    }

    // Toont de huidige stelling in de StellingArea
    private void ToonHuidigeStelling()
    {
        StellingArea.Text = _stellingen.Count == 0
            ? "Geen stellingen gevonden."
            : _stellingen[_index].Tekst;
    }

    // Event handlers voor de knoppen
    private void OnClickEens(object? sender, EventArgs e) => Beantwoord("eens");
    private void OnClickGeenMening(object? sender, EventArgs e) => Beantwoord("geen mening");
    private void OnClickOneens(object? sender, EventArgs e) => Beantwoord("oneens");

    // Beantwoordt de huidige stelling en gaat naar de volgende of naar de eindpagina
    private async void Beantwoord(string keuze)
    {
        try
        {
            if (_stellingen.Count == 0) return;

            _antwoorden.Opslaan(_stellingen[_index].Id, keuze);
            _index++;

            if (_index >= _stellingen.Count)
                await Shell.Current.GoToAsync("//EindPage");
            else
                ToonHuidigeStelling();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Fout", ex.Message, "OK");
        }
    }
}