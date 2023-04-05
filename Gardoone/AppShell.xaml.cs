using Gardoone.Views;

namespace Gardoone;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(TripPage),typeof(TripPage));
		Routing.RegisterRoute(nameof(AddTrip),typeof(AddTrip));
		Routing.RegisterRoute(nameof(SettingsPage),typeof(SettingsPage));
	}
}
