using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QrPassMobail.Models;
using QrPassMobail.Services;
using QrPassMobail.ViewModels;
using QrPassMobail.Views;

using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace QrPassMobail.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {

        [ObservableProperty]
        private string uName, pass;
        public LoginViewModel()
        {

        }
        [RelayCommand]
        private async void Login()
        {
            IsBusy = true;
            try
            {
                if (string.IsNullOrWhiteSpace(UName) || string.IsNullOrWhiteSpace(Pass))
                {
                    ShowWarning("Ошибка", "Заполните поля");
                    IsBusy = false;
                    return;
                }
                // await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
                var numb = UName.Replace("+", "").Replace(" ", "");
                if (UName == UserName && Pass == Password && !string.IsNullOrWhiteSpace(Preferences.Get("token", "")) ||
            !string.IsNullOrWhiteSpace(Preferences.Get("token_type", "")))
                {
                    await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
                    MessagingCenter.Send(this, "CheckUser");
                }
                var response = await DataStore.LoginAsync(new UserDto { UserName = numb, Password = Pass });
                if (UName != UserName)
                {

                }
                SaveUserDadta();
                Preferences.Set("token", response);
                Preferences.Set("token_type", $"bearer");

            }
            catch (Exception ex)
            {
                // await Shell.Current.GoToAsync($"//{nameof(MainPage)}");

                IsBusy = false;
                ShowWarning("Ошибка", ex.Message); return;





            }
            IsBusy = false;
            await Shell.Current.GoToAsync($"{nameof(MainPage)}");
        }
        private void SaveUserDadta()
        {
            UserName = UName;
            Password = Pass;
        }
    }
}
