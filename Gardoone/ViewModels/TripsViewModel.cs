using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoahDB;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gardoone.Views;
using System.ComponentModel;

namespace Gardoone.ViewModels
{
    public partial class TripsViewModel : ObservableObject
    {
        public TripsViewModel()
        {
            //LoahDb.Delete("Trips", "Gardoone");
            //LoahDb.Delete("Texts", "Gardoone");
            LoadTrips();
        }
       
        public ObservableCollection<Trip> TripsCollection { get; set; } = new ObservableCollection<Trip>();
        
        public void LoadTrips()
        {
            TripsCollection.Clear();
            var TripsLoah=new Loah<List<Trip>>("Trips","Gardoone");
            if (TripsLoah.Get()!=null)
            {
                if (TripsLoah.Get().Count==0)
                {
                    IsNotNull=false;
                    IsNull=true;
                }
                else
                {
                    IsNotNull=true;
                    IsNull=false;
                }
                
                foreach (var item in TripsLoah.Get())
                {
                    TripsCollection.Add(item);
                }

            }
            else
            {
                IsNotNull=false;
                IsNull=true;
            }
           
        }


        [ObservableProperty]
        bool isNull;
        [ObservableProperty]
        bool isNotNull;
        [ObservableProperty]
        Trip selectedTrip;
        [RelayCommand]
        void GoToTrip()
        {
            if (SelectedTrip!=null)
            {
                Shell.Current.GoToAsync($"{nameof(TripPage)}", new Dictionary<string, object>
                {
                    { "Trip",SelectedTrip }
                });
                SelectedTrip=null;
            }
        }
        [RelayCommand]
        void GoToAddTrip()
        {
            Shell.Current.GoToAsync(nameof(AddTrip));
        }
        [RelayCommand]
        void GoToSettings()
        {
            Shell.Current.GoToAsync(nameof(SettingsPage));
        }
    }
}
