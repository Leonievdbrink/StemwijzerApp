using StemwijzerApp;

namespace StemwijzerApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(PartijenPage), typeof(PartijenPage));
            Routing.RegisterRoute(nameof(PartijDetailPage), typeof(PartijDetailPage));
        }
    }
}