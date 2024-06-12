using Matchplanner.Pages;
using Matchplanner.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace Matchplanner
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
                });
            // Register IHttpClientFactory
            builder.Services.AddHttpClient();

            // Register AuthService as IAuthService
            builder.Services.AddTransient<IAuthService, AuthService>();

            // Register LoginPage
            builder.Services.AddTransient<LoginPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

       
}

    public static class MauiProgramExtensions
    {
        public static IServiceCollection AddCustomApiHttpClient(this IServiceCollection services)
        {
            services.AddSingleton<IPlatformHttpMessageHandler>(_ =>
            {
                return null;
            });

            services.AddHttpClient(AppConstants.HttpClientName, httpClient =>
            {
                var baseAddress =
                        DeviceInfo.Platform == DevicePlatform.Android
                            ? "https://10.0.2.2:7157"
                            : "https://localhost:7157";

                httpClient.BaseAddress = new Uri(baseAddress);
            })
                .ConfigureHttpMessageHandlerBuilder(builder =>
                {
                    var platfromHttpMessageHandler = builder.Services.GetRequiredService<IPlatformHttpMessageHandler>();
                    builder.PrimaryHandler = platfromHttpMessageHandler.GetHttpMessageHandler();
                });

            return services;
        }
    }
}
