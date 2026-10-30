using StemwijzerApp.Models;

namespace StemwijzerApp;

public partial class PartijDetailPage : ContentPage, IQueryAttributable
{
    public PartijDetailPage()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("Partij", out var value) && value is Partij partij)
            BindingContext = partij;
    }

    private async void OnBackTapped(object? sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}