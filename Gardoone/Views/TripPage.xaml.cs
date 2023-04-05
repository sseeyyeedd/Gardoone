using Gardoone.ViewModels;

namespace Gardoone.Views;

public partial class TripPage : ContentPage
{
	public TripPage(TripViewModel tripViewModel)
	{
		InitializeComponent();
		BindingContext =tripViewModel;
		ViewModel= tripViewModel;
	}
	TripViewModel ViewModel { get;  }
    
    private void ContentPage_Disappearing(object sender, EventArgs e)
    {
        ViewModel.SaveTrip();
        ViewModel.ImageUrl=string.Empty;
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        ViewModel.LoadTexts();
        
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new Modals.DeleteModal(ViewModel.Trip.Id));


    }
}