using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Gardoone.Modals;
using Gardoone.Views;
using LoahDB;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Gardoone.ViewModels
{
    public partial class AddTripViewModel:ObservableObject
    {
        Loah<List<Trip>> TripsLoah;
        [ObservableProperty]
        string title;
        [ObservableProperty]
        string description;
        [ObservableProperty]
        string destination;
        [ObservableProperty]
        string startTime;
        [ObservableProperty]
        string endTime;
        [ObservableProperty]
        string error;
        [ObservableProperty]
        string mainImage;
        [RelayCommand]
        void AddNewTrip(object obj)
        {
            if (string.IsNullOrEmpty(MainImage))
            {
                MainImage="/Resources/Images/travel.jpg";
            }
            if (string.IsNullOrEmpty(Title))
            {
                if(string.IsNullOrEmpty(Error))
                {
                    Error+="شما باید عنوان سفر را وارد کنید";
                }
                
            }
            else
            {
                if (!string.IsNullOrEmpty(Error))
                {
                    Error=string.Empty;
                }

            }
            if (string.IsNullOrEmpty(Error))
            {
                TripsLoah= new Loah<List<Trip>>("Trips", "Gardoone");
                var trips = TripsLoah.Get();
                if (trips==null)
                {
                    trips= new List<Trip>();
                }
                var newTrip = new Trip()
                {
                    Id=Guid.NewGuid(),
                    Title = Title,
                    Description = Description,
                    Destination = Destination,
                    StartTime=StartTime,
                    EndTime=EndTime,
                    MainUrl= MainImage


                };
                trips.Add(newTrip);
                TripsLoah.Set(trips);
                Shell.Current.GoToAsync("..");
            }
            



        }

        [RelayCommand]
       async void FilePickerClicked(object obj)
        {
            var options = new PickOptions();
            options.PickerTitle="تصویر اصلی سفر";
            options.FileTypes=FilePickerFileType.Images;
            var result = await FilePicker.Default.PickAsync(options);
            if (result != null)
            {
                MainImage= result.FullPath;
            }
        }
        [RelayCommand]
        void GoBack()
        {
            Shell.Current.GoToAsync("..");
        }
        [RelayCommand]
        void GoToSettings()
        {
            Shell.Current.GoToAsync(nameof(SettingsPage));
        }
        public void ClearAll()
        {
            Title="";
            Description="";
            Destination="";
            StartTime="";
            EndTime="";
            MainImage="";
            Error="";
        }
    }
}
