using Microsoft.Extensions.Logging;
using StemwijzerApp.Helpers;
using StemwijzerApp.Services;
using StemwijzerApp.Services.Api;
using StemwijzerApp.Services.Interfaces;
using StemwijzerApp.Services;
//using StemwijzerApp.Views;

namespace StemwijzerApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Poppins-Medium.ttf", "PoppinsMedium");
                    fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // HttpClient voor de PHP API
            builder.Services.AddSingleton(new HttpClient
            {
                BaseAddress = new Uri(Constants.BaseUrl),
                Timeout = TimeSpan.FromSeconds(10)
            });

            // Services
            builder.Services.AddSingleton<IStellingService, ApiStellingService>();

            // Pagina's (zodat ze services via de constructor krijgen)
            builder.Services.AddTransient<QuestionPage>();
            builder.Services.AddSingleton<IPartijService, ApiPartijService>();

            builder.Services.AddTransient<PartijenPage>();
            builder.Services.AddTransient<PartijDetailPage>();
            builder.Services.AddSingleton<IMatchService, MatchService>();
            builder.Services.AddSingleton<AntwoordenService>();
            builder.Services.AddSingleton<IMatchService, MatchService>();
            builder.Services.AddTransient<QuestionPage>();
            builder.Services.AddTransient<ResultaatPage>();

            return builder.Build();
        }
    }
}