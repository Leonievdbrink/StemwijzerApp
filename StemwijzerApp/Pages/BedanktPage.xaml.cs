using System;
namespace StemwijzerApp.Pages
{
    public partial class BedanktPage : ContentPage
    {
        public BedanktPage()
        {
            InitializeComponent();
        }

        private async void OnResultsClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("ResultsPage");
        }
    }
}
