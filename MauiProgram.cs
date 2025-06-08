using GestãoAgro;
using GestaoAgro.Services;
using GestãoAgro.View;
using GestaoAgro.ViewModels;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui;
using GestaoAgro.View.Forms;
using GestaoAgro.ViewModels.Forms;

namespace GestaoAgro
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseMauiCommunityToolkitCore()
                .UseMauiCommunityToolkit(options =>
                {
                    options.SetShouldEnableSnackbarOnWindows(true);
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("duotone.otf", "duotone");
                    fonts.AddFont("poppinsl.ttf", "poppinsl");
                    fonts.AddFont("poppinst.ttf", "poppinst");
                    fonts.AddFont("poppinsb.ttf", "poppinsb");
                    fonts.AddFont("prolight.otf", "prolight");
                });

            // Add views
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<CattleFarmPage>();
            builder.Services.AddTransient<FishFarmPage>();
            builder.Services.AddTransient<FarmingPage>();
            builder.Services.AddTransient<CartPage>();
            builder.Services.AddTransient<StockPage>();

            // Add forms
            builder.Services.AddTransient<FormNewAnimal>();
            builder.Services.AddTransient<FormNewVaccine>();

            // Add view models
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<CattleFarmViewModel>();

            // Add forms view models
            builder.Services.AddTransient<FormNewAnimalViewModel>();
            builder.Services.AddTransient<FormNewVaccineViewModel>();

            // Add services
            builder.Services.AddTransient<DBService>();
            builder.Services.AddSingleton<OperationStateService>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
