using Microsoft.Extensions.Logging;
using SMIAPP2026.Services;
using SMIAPP2026.Shared;
using SMIAPP2026.Shared.Services;

namespace SMIAPP2026
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
                });

            // Add device-specific services used by the SMIAPP2026.Shared project
            builder.Services.AddSingleton<IFormFactor, FormFactor>();
            builder.Services.AddSingleton<DatabaseService>();
            builder.Services.AddSingleton<SecureStorageService>();
            builder.Services.AddSingleton<HttpClient>(sp =>
            {
                var client = new HttpClient
                {
                };
                return client;
            });
            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
