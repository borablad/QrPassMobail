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
    public partial class LoginPage : ContentPage
    {
        private LoginViewModel vm;
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
            vm=(LoginViewModel)BindingContext;
        }

            protected override void OnAppearing()
            {
                base.OnAppearing();
                vm.onAppering();
            }
    }
}