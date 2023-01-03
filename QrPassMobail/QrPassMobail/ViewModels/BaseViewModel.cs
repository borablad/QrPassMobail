using QrPassMobail.Models;
using QrPassMobail.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using CommunityToolkit.Mvvm.ComponentModel;
using Xamarin.CommunityToolkit.Extensions;
using QrPassMobail.Widgets;
using Xamarin.Essentials;
using QrPassMobail.Services.rest_and_interface;

namespace QrPassMobail.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        public string AppVersion = "1,001";
        //public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();
        public RestI DataStore => DependencyService.Get<RestI>();

        [ObservableProperty]
        bool isBusy = false;
        [ObservableProperty]
        string title = string.Empty;
        public string UserName { get => Preferences.Get(nameof(UserName), ""); set => Preferences.Set(nameof(UserName), value); }
        public string Password { get => Preferences.Get(nameof(Password), ""); set => Preferences.Set(nameof(Password), value); }
        public static string Sheme { get => Preferences.Get(nameof(Sheme), "http"); set => Preferences.Set(nameof(Sheme), value); }
        public static string Port { get => Preferences.Get(nameof(Port), "8000"); set => Preferences.Set(nameof(Port), value); }
        public static string HostUrl { get => Preferences.Get(nameof(HostUrl), "192.168.31.62"); set => Preferences.Set(nameof(HostUrl), value); }
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        public async void ShowWarning(string title, string message)
        {
            try
            {
                var popup = new WarningView();
                var popupvm = (WarningViewModel)popup.BindingContext;
                popupvm.Title = title;
                popupvm.Message = message;
                var page = await App.Current.MainPage.ShowPopupAsync(popup);
            }
            catch (Exception ex)
            {

            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
