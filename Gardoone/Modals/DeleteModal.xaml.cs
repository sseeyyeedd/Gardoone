using LoahDB;

namespace Gardoone.Modals;

public partial class DeleteModal : ContentPage
{
	public DeleteModal(Guid guid)
	{
		InitializeComponent();
        Id= guid;
	}
    public Guid Id { get;  }
    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        var tripsLoah = new Loah<List<Models.Trip>>("Trips", "Gardoone");
        var trips = tripsLoah.Get()==null ? new List<Models.Trip>() : tripsLoah.Get();
        if (trips.FindIndex(x => x.Id==Id)!=-1)
        {
            trips.RemoveAt(trips.FindIndex(x => x.Id==Id));
        }
        tripsLoah.Set(trips);
        Shell.Current.GoToAsync("../..");
    }
}