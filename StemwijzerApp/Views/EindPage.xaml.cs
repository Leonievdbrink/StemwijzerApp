namespace StemwijzerApp;

public partial class EindPage : ContentPage
{
    public EindPage()
    {
        InitializeComponent();
    }

    //handler als er op de naar resultaten knop word geklikt
    private async void OnResultatenClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//ResultaatPage");
    }
}