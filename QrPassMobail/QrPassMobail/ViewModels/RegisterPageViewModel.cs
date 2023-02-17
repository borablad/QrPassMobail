
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QrPassMobail.Models;
using QrPassMobail.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace QrPassMobail.ViewModels
{
    public partial class RegisterPageViewModel:BaseViewModel
    {
        [ObservableProperty]
        private string uname, pass, passwordRepeat;

        private bool isAdmin;
        public RegisterPageViewModel() { }

        [RelayCommand]
        private async void Register()
        {
            if (string.IsNullOrWhiteSpace(Uname) || string.IsNullOrWhiteSpace(Pass) || string.IsNullOrWhiteSpace(PasswordRepeat))
            {
                ShowWarning("Ошибка", "Введите все поля");
                return;
            }

          /*  if (Pass.Length < 8) {
                ShowWarning("Ошибка", "Пароль должен содержать не менее 8 симбволов");
                return; 
            }*/
            if (Pass != PasswordRepeat)
            {
                ShowWarning("Ошибка", "Пароли не совпадают");
                return ;
            }

            try
            {

             /*   Preferences.Set("token", "");
                Preferences.Set("token_type", "");*/
                var response = await DataStore.RegisterAsync(new UserDto { UserName = Uname, Password = Pass });


                var res = await DataStore.LoginAsync(new UserDto { UserName = Uname, Password = Pass,IsAdmin=isAdmin });
                    SaveUserDadta();
                
            
                Preferences.Set("access_token", res);
                Preferences.Set("auth_scheme", $"Bearer");
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            }
            catch(Exception ex)
            {
                if(ex.ToString().ToLower().Contains("exsist"))
                {
                    ShowWarning("Ошибка", "Пользователь уже существует");
                    return;
                }
                ShowWarning("Ошибка", ex.ToString());
            }
            
        }


        private void SaveUserDadta()
        {
            UserName = Uname;
            Password = Pass;
        }
        [RelayCommand]
        private void Admin()
        {
            isAdmin= true;
            ShowToast("Заебись ты админ челллл");
           // ShowWarning("Заебись", "ты админ челллл");
        }
    }
}
