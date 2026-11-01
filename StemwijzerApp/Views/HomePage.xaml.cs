namespace StemwijzerApp;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

    //handler als er op de begin knop word geklikt
    private async void OnBeginClicked(object sender, EventArgs e)
    {
        try
        {
            await Shell.Current.GoToAsync("//QuestionPage");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Fout", ex.ToString(), "OK");
        }
    }

    //handler als er op de partijen knop word geklikt
    private async void OnPartijenTapped(object? sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(PartijenPage));
    }
}