using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Gardoone.Views;
using LoahDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gardoone.ViewModels
{
    [QueryProperty(nameof(Trip), "Trip")]
    public partial class TripViewModel : ObservableObject
    {
        public TripViewModel()
        {
            
        }
        [ObservableProperty]
        Models.Trip trip;
        [ObservableProperty]
        string imageUrl;
        
        public ObservableCollection<Models.Text> TextsCollection { get; set; } = new ObservableCollection<Models.Text>();
        public void SaveTrip()
        {
            var tripsLoah = new Loah<List<Models.Trip>>("Trips", "Gardoone");
            var trips = tripsLoah.Get()==null ? new List<Models.Trip>() : tripsLoah.Get();
            if (trips.FindIndex(x => x.Id==Trip.Id)!=-1)
            {
                trips[trips.FindIndex(x => x.Id==Trip.Id)]=Trip;
                tripsLoah.Set(trips);
            }
            var textsLoah = new Loah<List<Models.Text>>("Texts", "Gardoone");
            var textList=new List<Models.Text>();
            textList=textsLoah.Get()==null ? new List<Models.Text>() : textsLoah.Get();
            foreach (var item in TextsCollection)
            {
                int i = textList.FindIndex(x => x.Id==item.Id);
                if (i==-1)
                {
                    textList.Add(item);
                }
                else
                {
                    textList[i]= item;
                }
                
            }
            
            textsLoah.Set(textList);
        }
        public void LoadTexts() {

            ImageUrl=Trip.MainUrl;
            TextsCollection.Clear();
            var textLoah = new Loah<List<Models.Text>>("Texts", "Gardoone");
            
            if (textLoah.Get()!=null)
            {
                List<Models.Text> textList;
                if (textLoah.Get().Where(x => x.TripId==Trip.Id).Count()!=0)
                {
                     textList = textLoah.Get().Where(x => x.TripId==Trip.Id).ToList();
                }
                else
                {
                    textList = new List<Models.Text>();
                }
                
                foreach (var item in textList)
                {
                    TextsCollection.Add(item);
                }

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
            [RelayCommand]
            void GoToAddTrip()
            {
                Shell.Current.GoToAsync(nameof(AddTrip));
            }
            [RelayCommand]
            void AddText()
            {
            
                TextsCollection.Add(new Models.Text() { Id=Guid.NewGuid(),TripId=Trip.Id ,Title="",Body="",Url=""});
            }
        [RelayCommand]
        async void ChangePhoto()
        {
            
            var options = new PickOptions();
            options.PickerTitle="ویرایش تصویر اصلی سفر";
            options.FileTypes=FilePickerFileType.Images;
            
            var result = await FilePicker.Default.PickAsync(options);
            if (result != null)
            {
                Trip.MainUrl= result.FullPath;
                ImageUrl= result.FullPath;
            }
            
        }
        
      
     

    }
}
