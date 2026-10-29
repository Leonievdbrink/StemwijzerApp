using StemwijzerApp.Models;
using StemwijzerApp.Services.Interfaces;

namespace StemwijzerApp;

public partial class QuestionPage : ContentPage
{
    private readonly IStellingService _stellingService;
    private List<Stelling> _stellingen = new();
    private int _index = 0;

    public QuestionPage(IStellingService stellingService)
    {
        InitializeComponent();
        _stellingService = stellingService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadStellingenAsync();
    }

    private async Task LoadStellingenAsync()
    {
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
        if (_stellingen.Count == 0)
        {
            StellingArea.Text = "Geen stellingen gevonden.";
            return;
        }

        if (_index >= _stellingen.Count)
        {
            StellingArea.Text = "Alle stellingen beantwoord!";
            return;
        }

        StellingArea.Text = _stellingen[_index].Tekst;
    }

    private void OnClickEens(object? sender, EventArgs e)
    {
        // TODO: antwoord opslaan (bijv. 1 = eens)
        Volgende();
    }

    private void OnClickGeenMening(object? sender, EventArgs e)
    {
        // TODO: antwoord opslaan (bijv. 0 = geen mening)
        Volgende();
    }

    private void OnClickOneens(object? sender, EventArgs e)
    {
        // TODO: antwoord opslaan (bijv. -1 = oneens)
        Volgende();
    }

    private void Volgende()
    {
        _index++;
        ToonHuidigeStelling();
    }
}