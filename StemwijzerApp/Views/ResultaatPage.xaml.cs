using StemwijzerApp.Services;
using StemwijzerApp.Services.Interfaces;

namespace StemwijzerApp;

public partial class ResultaatPage : ContentPage
{
    private readonly IMatchService _match;
    private readonly AntwoordenService _antwoorden;

    public ResultaatPage(IMatchService match, AntwoordenService antwoorden)
    {
        InitializeComponent();
        _match = match;
        _antwoorden = antwoorden;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Controleer of er antwoorden zijn voordat we de berekening uitvoeren
        try
        {
            var response = await _match.BerekenAsync(_antwoorden.Antwoorden);
            var resultaten = response.Partijen;

            if (resultaten.Count == 0)
            {
                BesteMatchLabel.Text = "Geen partijen gevonden";
                return;
            }

            // Beste match
            var beste = resultaten[0];
            BesteMatchLabel.Text = $"{beste.Naam} {beste.Percentage:0}% overeenkomst";

            // Top 5
            Top5List.ItemsSource = resultaten.Take(5).ToList();

            // Rooster
            Kompas.Drawable = new KompasDrawable
            {
                Partijen = resultaten,
                Gebruiker = (response.Gebruiker.X, response.Gebruiker.Y)
            };
            Kompas.Invalidate(); // forceer opnieuw tekenen
        }
        catch (Exception ex)
        {
            await DisplayAlert("Fout", ex.Message, "OK");
        }
    }

    private async void OnOpnieuwClicked(object? sender, EventArgs e)
    {
        _antwoorden.Wis();
        await Shell.Current.GoToAsync("//HomePage");
    }
}