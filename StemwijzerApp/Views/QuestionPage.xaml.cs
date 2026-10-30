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
        base.OnAppearing();
        _antwoorden.Wis();

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

    private void ToonHuidigeStelling()
    {
        StellingArea.Text = _stellingen.Count == 0
            ? "Geen stellingen gevonden."
            : _stellingen[_index].Tekst;
    }

    private void OnClickEens(object? sender, EventArgs e) => Beantwoord("eens");
    private void OnClickGeenMening(object? sender, EventArgs e) => Beantwoord("geen mening");
    private void OnClickOneens(object? sender, EventArgs e) => Beantwoord("oneens");

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