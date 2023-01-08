using QrPassMobail.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QrPassMobail.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {

        private SettinsViewModel vm;
        public SettingsPage()
        {
            InitializeComponent();
            vm = (SettinsViewModel)BindingContext;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.OnAppering();
        }


        #region theme
        //включение системной темы
        private void Switch_Toggled_1(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                if (vm.SystemTheme)
                    vm.ThemeSelectionChanged("0");
            }
            else
            {
                if (!vm.DarkTheme && !vm.LightTheme) vm.SystemTheme = true;
            }
        }

        //включение светлой темы
        private void Switch_Toggled_2(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                if (vm.LightTheme)
                    vm.ThemeSelectionChanged("1");
            }
            else
            if (!vm.DarkTheme && !vm.SystemTheme) vm.LightTheme = true;

        }

        //включение тёмной темы
        private void Switch_Toggled_3(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                if (vm.DarkTheme)
                    vm.ThemeSelectionChanged("2");
            }
            else
            if (!vm.SystemTheme && !vm.LightTheme) vm.DarkTheme = true;
        }
        #endregion

    }
}