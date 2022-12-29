﻿using CommunityToolkit.Mvvm.ComponentModel;
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
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            return;
            //await Shell.Current.GoToAsync($"{nameof(MainPage)}");
            //return;
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
               
                var response = await DataStore.LoginAsync(new UserDto { UserName = numb, Password = Pass });
              
                    SaveUserDadta();
               
               
                Preferences.Set("token", response);
                Preferences.Set("token_type", $"Bearer");

            }
            catch (Exception ex)
            {
                // await Shell.Current.GoToAsync($"//{nameof(MainPage)}");

                IsBusy = false;
                ShowWarning("Ошибка", ex.Message); return;





            }
            IsBusy = false;
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }

        [RelayCommand]
        private  async void GoToRegister() {
            await Shell.Current.GoToAsync($"//{nameof(RegisterPage)}");
        }
        private void SaveUserDadta()
        {
            UserName = UName;
            Password = Pass;
        }
    }
}