using QrPassMobail.ViewModels;
using QrPassMobail.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace QrPassMobail
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(StatPage), typeof(StatPage));
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            
        }
        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }

    }
}
