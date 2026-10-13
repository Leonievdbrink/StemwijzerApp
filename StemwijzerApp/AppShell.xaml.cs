using Stemwijzer;

namespace StemwijzerApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("StandpuntPage", typeof(StandpuntPage));
        }
    }
}