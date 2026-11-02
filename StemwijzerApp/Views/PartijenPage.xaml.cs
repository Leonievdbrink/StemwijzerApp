using StemwijzerApp.Models;
using StemwijzerApp.Services.Interfaces;

namespace StemwijzerApp;


public partial class PartijenPage : ContentPage
{
    private readonly IPartijService _partijService;

    public PartijenPage(IPartijService partijService)
    {
        InitializeComponent();
        _partijService = partijService;
    }

    // Haalt de lijst van partijen op wanneer de pagina verschijnt
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        try
        {
            PartijenList.ItemsSource = await _partijService.GetPartijenAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Fout", $"Partijen konden niet worden geladen: {ex.Message}", "OK");
        }
    }

    // handler voor wanneer een partij wordt geselecteerd
    private async void OnPartijSelected(object? sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not Partij partij)
            return;

        PartijenList.SelectedItem = null; // zodat je dezelfde partij opnieuw kunt kiezen

        await Shell.Current.GoToAsync(nameof(PartijDetailPage),
            new Dictionary<string, object> { { "Partij", partij } });
    }

    // handler voor wanneer de terug knop wordt ingedrukt

    private async void OnBackTapped(object? sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}