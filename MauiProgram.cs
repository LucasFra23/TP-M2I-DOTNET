using Microsoft.Extensions.Logging;
using TP_M2I_DOTNET.Api;
using TP_M2I_DOTNET.ViewModels;

namespace TP_M2I_DOTNET
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

            builder.Services.AddSingleton<TasksViewModel>();
            builder.Services.AddTransient<TasksApi>();
            builder.Services.AddHttpClient("tasks-api", client =>
            {
                client.BaseAddress = new Uri("https://localhost:5001/api"); //A remplacer par l'uri de l'api
            });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
