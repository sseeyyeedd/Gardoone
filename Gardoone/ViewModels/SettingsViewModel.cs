using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gardoone.ViewModels
{
    public partial class SettingsViewModel:ObservableObject
    {
        [RelayCommand]
        void GoBack()
        {
            Shell.Current.GoToAsync("..");
        }
        [RelayCommand]
        void GoToAddTrip()
        {
            Shell.Current.GoToAsync(nameof(AddTrip));
        }
        [RelayCommand]
        async void Link(string url)
        {
            Uri uri = new Uri(url);
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
        [RelayCommand]
        void CallDeveloper()
        {
            if (PhoneDialer.Default.IsSupported)
                PhoneDialer.Default.Open("+989928603203");
        }
    }
}
