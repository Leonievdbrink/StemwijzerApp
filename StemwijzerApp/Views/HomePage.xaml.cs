namespace Stemwijzer;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

    private async void OnBeginClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("StandpuntPage");
    }
}