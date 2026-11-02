using StemwijzerApp.Models;

namespace StemwijzerApp;

public partial class PartijDetailPage : ContentPage, IQueryAttributable
{
    public PartijDetailPage()
    {
        InitializeComponent();
    }

    //funtie om query atrubuten te gebruiken om de partij door te geven naar de detail page
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("Partij", out var value) && value is Partij partij)
            BindingContext = partij;
    }

    //handler als er op de terug knop word geklikt
    private async void OnBackTapped(object? sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}