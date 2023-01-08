using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace QrPassMobail.ViewModels
{
    public partial class SettinsViewModel : BaseViewModel
    {
        [ObservableProperty]
        private bool systemTheme, lightTheme, darkTheme, isExpanded;
        [ObservableProperty]
        private string userThem;


        public string SchemeM { get { return Sheme; } set { Sheme = value; } }
        public string PortM { get { return Port; } set { Port = value; } }
        public string HostM { get { return HostUrl; } set { HostUrl = value; } }

        public int userTheme
        {
            get => Preferences.Get("CastTheme", 0);
            set
            {
                Preferences.Set("CastTheme", value);
                OnPropertyChanged(nameof(userTheme));
            }
        }

        public SettinsViewModel()
        {

        }

        internal async void OnAppering()
        {
            if (userTheme == 2) DarkTheme = true;
            else if (userTheme == 1) LightTheme = true;
            else SystemTheme = true;

            

        }

        [RelayCommand] // Смена темы
        public void ThemeSelectionChanged(string parm)
        {
            int preferens = int.Parse(parm);
            userTheme = preferens;
            switch (preferens)
            {
                case 2:
                    {

                        Xamarin.Forms.Application.Current.UserAppTheme = OSAppTheme.Dark;
                        UserThem = "Тёмная";
                        SystemTheme = false;
                        LightTheme = false;




                        break;
                    }
                case 1:
                    {
                        Xamarin.Forms.Application.Current.UserAppTheme = OSAppTheme.Light;
                        UserThem = "Светлая";
                        SystemTheme = false;
                        DarkTheme = false;


                        break;
                    }

                default:
                    {
                        Xamarin.Forms.Application.Current.UserAppTheme = OSAppTheme.Unspecified;
                        UserThem = "Системная";
                        LightTheme = false;
                        DarkTheme = false;

                        break;
                    }
            }
        }

    }
}
