namespace StemwijzerApp;

public partial class EindPage : ContentPage
{
    public EindPage()
    {
        InitializeComponent();
    }

    private async void OnResultatenClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//ResultaatPage");
    }
}