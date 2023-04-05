using Gardoone.ViewModels;
using Gardoone.Views;
using Microsoft.Extensions.Logging;

namespace Gardoone;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("Tanha.ttf", "Tanha");
			});
		builder.Services.AddSingleton<TripViewModel>();
		builder.Services.AddSingleton<TripPage>();
		builder.Services.AddSingleton<TripsViewModel>();
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<AddTripViewModel>();
		builder.Services.AddSingleton<AddTrip>();
		builder.Services.AddSingleton<SettingsViewModel>();
		builder.Services.AddSingleton<SettingsPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
