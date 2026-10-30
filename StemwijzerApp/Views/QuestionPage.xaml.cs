using StemwijzerApp.Models;
using StemwijzerApp.Services.Interfaces;
using StemwijzerApp.Pages;

namespace StemwijzerApp;

public partial class QuestionPage : ContentPage
{
    private readonly IStellingService _stellingService;
    private List<Stelling> _stellingen = new();
    private readonly List<int> _antwoorden = new();
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
            _antwoorden.Clear();
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
        VerwerkAntwoord(1);
    }

    private void OnClickGeenMening(object? sender, EventArgs e)
    {
        VerwerkAntwoord(0);
    }

    private void OnClickOneens(object? sender, EventArgs e)
    {
        VerwerkAntwoord(-1);
    }

    private async void VerwerkAntwoord(int antwoord)
    {
        _antwoorden.Add(antwoord);
        _index++;

        if (_index >= _stellingen.Count)
        {
            await Shell.Current.GoToAsync("BedanktPage");
            return;
        }

        ToonHuidigeStelling();
    }
}