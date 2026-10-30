namespace StemwijzerApp;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

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

    private async void OnPartijenTapped(object? sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(PartijenPage));
    }
}