using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QrPassMobail.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace QrPassMobail.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {

        private string userLogin, userPassword;
        public string UserLogin { get => userLogin; set { userLogin = value; OnPropertyChanged(userLogin); } }
        public string UserPassword { get => userPassword; set { userPassword = value; OnPropertyChanged(userPassword); } }
        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }
    }
}
