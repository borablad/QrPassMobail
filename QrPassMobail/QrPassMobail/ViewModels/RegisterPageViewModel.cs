
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QrPassMobail.Models;
using QrPassMobail.Views;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace QrPassMobail.ViewModels
{
    public partial class RegisterPageViewModel:BaseViewModel
    {
        [ObservableProperty]
        private string iIN, pass, passwordRepeat, userName,userLastName;

        public string UserFullName { get { return UserName+UserLastName;} }

        private bool isAdmin;
        public RegisterPageViewModel() { }

        [RelayCommand]
        private async void Register()
        {
            if (string.IsNullOrWhiteSpace(IIN) || string.IsNullOrWhiteSpace(Pass) || string.IsNullOrWhiteSpace(PasswordRepeat)||string.IsNullOrWhiteSpace(UserName)||string.IsNullOrWhiteSpace(UserLastName))


            {
                ShowWarning("Ошибка", "Введите все поля");
                return;
            }

           /* if (IIN.Length != 12)
            {
                ShowWarning("Ошибка", "Введите действущий ИИН");
                return;
            }*/

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

                var response = await DataStore.RegisterAsync(new UserDto { UserName = IIN, Password = Pass });


                var res = await DataStore.LoginAsync(new UserDto { UserName = IIN, Password = Pass,IsAdmin=isAdmin });
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
            UserName = IIN;
            Password = Pass;
            USerFullName = UserFullName;
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
