using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QrPassMobail.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace QrPassMobail.ViewModels
{
    public partial class RegisterPageViewModel:BaseViewModel
    {
        [ObservableProperty]
        private string uname, pass, passwordRepeat;
        public RegisterPageViewModel() { }

        [RelayCommand]
        private async void Register()
        {
            if (string.IsNullOrWhiteSpace(Uname) || string.IsNullOrWhiteSpace(Pass) || string.IsNullOrWhiteSpace(PasswordRepeat))
            {
                ShowWarning("Ошибка", "Введите все поля");
                return;
            }

            if (Pass.Length < 8) {
                ShowWarning("Ошибка", "Пароль должен содержать не менее 8 симбволов");
                return; 
            }
            if (Pass != PasswordRepeat)
            {
                ShowWarning("Ошибка", "Пароли не совпадают");
                return ;
            }

            try
            {
                var numb = Uname.Replace("+", "").Replace(" ", "");

                var response = await DataStore.RegisterAsync(new UserDto { UserName = numb, Password = Pass });
             
                    SaveUserDadta();
                
            
                Preferences.Set("token", response);
                Preferences.Set("token_type", $"bearer");
            }
            catch(Exception ex)
            {
                ShowWarning("Ошибка", ex.ToString());
            }
            
        }
        private void SaveUserDadta()
        {
            UserName = Uname;
            Password = Pass;
        }
    }
}
