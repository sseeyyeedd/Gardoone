using Gardoone.ViewModels;
using LoahDB;
using Models;

namespace Gardoone;

public partial class AddTrip : ContentPage
{
	public AddTrip(AddTripViewModel addTripViewModel)
	{
		InitializeComponent();
        BindingContext=addTripViewModel;
        ViewModel=addTripViewModel;
        
    }

    private void ContentPage_Disappearing(object sender, EventArgs e)
    {
        ViewModel.ClearAll();
    }
    public AddTripViewModel ViewModel { get;  }



}