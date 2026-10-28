namespace Stemwijzer;

public partial class StandpuntPage : ContentPage
{
    public StandpuntPage()
    {
        InitializeComponent();
    }

    private async void OnTerugTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}