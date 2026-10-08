namespace StemwijzerApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            // register route for results page so we can navigate with Shell.GoToAsync("ResultsPage")
            Routing.RegisterRoute("ResultsPage", typeof(Pages.ResultsPage));
        }
    }
}
