using Android.Widget;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using QrPassMobail.Models;
using QrPassMobail.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.CommunityToolkit.ObjectModel;

namespace QrPassMobail.ViewModels
{
    public partial class StatPageViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Visits> Visits { get; set; } = new ObservableRangeCollection<Visits>();
        public List<Visits> tempVisits { get; set; } = new List<Visits>();

        [ObservableProperty]
        private bool isClickEnterFilter, isClickAllFilter, isClickExitFilter;


        public StatPageViewModel()
        {

        }
        internal async void OnApperring()
        {
            try
            {
                tempVisits = await DataStore.getMyVisits();

            }
            catch
            {
                ShowWarning("Ошибка", "Данных нет");
            }
         
            tempVisits = new List<Visits>();
            tempVisits.Add(new Models.Visits { Date = DateTime.Now, id = "1", Username = "boblandy" });
            tempVisits.Add(new Models.Visits { Date = DateTime.Now, id = "1", Username = "boblandy" });
            tempVisits.Add(new Models.Visits { Date = DateTime.Now, id = "1", Username = "boblandy" });

            Visits.ReplaceRange(tempVisits);
            Filtred();

        }

       
        [RelayCommand]
        private async void DeleteAllVisits() {
            try
            {
                var b = await DataStore.DeleteAllVisits();
                if (b)
                {
                  
                    tempVisits = await DataStore.getMyVisits();
                    Visits.ReplaceRange(tempVisits);
                    ShowWarning("Успешно", "визиты полностью очищены");
                    return;
                }
               throw new Exception("Не удалось удалить посещения"); 
            }
            catch(Exception ex) { ShowWarning("Error", ex.Message); }
        }

        [RelayCommand]
        private async void DeleteUser(UserDto user)
        {
            if (user is null) return;

            try
            {
                var b = await DataStore.DeleteUser(user.Id);
                if (b)
                {
                    ShowWarning("Успешно", "Пользователь удален");
                    return;
                }
                throw new Exception("Не получилось удалить пользователя ");
            }catch(Exception ex)
            {
                ShowWarning("Ошибка", ex.Message);
            }
        }



        [RelayCommand]
        private void Filtred()
        {
            var tempVisitList = new List<Visits>();

            if (IsClickAllFilter)
            {
                Visits.ReplaceRange(tempVisits);
                return;
            }

            tempVisitList = IsClickEnterFilter ? tempVisits.Where(x => x.IsEnter).ToList() : new List<Visits>();
            tempVisitList = IsClickExitFilter ? tempVisits.Where(x => !x.IsEnter).ToList() : new List<Visits>();


            Visits.ReplaceRange(tempVisitList);
        
            
        }

    }
}
