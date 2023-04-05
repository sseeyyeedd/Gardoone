using LoahDB;
using Models;
using Gardoone.ViewModels;
namespace Gardoone;

public partial class MainPage : ContentPage
{
	public MainPage(TripsViewModel tripsViewModel)
	{
		InitializeComponent();
		BindingContext=tripsViewModel;
		ViewModel=tripsViewModel;
		Application.Current.UserAppTheme=AppTheme.Light;
    }
	public TripsViewModel ViewModel { get; set; }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        ViewModel.LoadTrips();
    }
}

