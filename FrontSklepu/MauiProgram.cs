﻿using FrontSklepu.Services;
using FrontSklepu.ViewModels;
using FrontSklepu.Views.Desktop;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;

namespace FrontSklepu
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<DesktopHomePageViewModel>();
            builder.Services.AddSingleton<DesktopHomePage>();

            builder.Services.AddSingleton<AddProductPage>();
            builder.Services.AddSingleton<AddProductPageViewModel>();

            builder.Services.AddHttpClient<IProductService, ProductService >();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
