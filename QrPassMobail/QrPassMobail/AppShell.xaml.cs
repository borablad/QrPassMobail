using QrPassMobail.ViewModels;
using QrPassMobail.Views;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
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
            Routing.RegisterRoute(nameof(NFCPage), typeof(NFCPage));

        }
        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
        // Замена цвета таббара
        private void ChangeTabColor()
        {
            if (DeviceInfo.Platform != DevicePlatform.iOS)
                return;

            Color selcolor = Color.FromHex("#66B2F0");
            Color unselcolor = Color.FromHex("#919191");


            for (int i = 0; i < MyTabbar.Items.Count; i++)
            {
                var img = (FontImageSource)MyTabbar.Items[i].Icon;
                bool isCurrentPage = MyTabbar.CurrentItem == MyTabbar.Items[i] ? true : false;
                MyTabbar.Items[i].Icon = new FontImageSource
                {
                    Glyph = img.Glyph,
                    FontFamily = img.FontFamily,
                    Size = isCurrentPage ? 30 : 25,
                    Color = isCurrentPage ? selcolor : unselcolor
                };
            }
        }

    }
}
