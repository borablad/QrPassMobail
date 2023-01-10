using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using ZXing.Mobile;
using Xamarin.Forms;
using QrPassMobail.Views;


namespace QrPassMobail.ViewModels
{
    public partial class MainPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private bool isSkanner = false;

        private int code = 0;

      public MainPageViewModel()
        {
            
        //    ShowWarning("Error", "havno");
        }
       public async Task ResultScan(int code)
        {
            if (code == this.code)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    ShowWarning("Ошибка", "Код уже отсканирован");


                });
                return;
            }
           if(IsSkanner) { return; }
            IsBusy = true;
           IsSkanner = true;
           
            try {  
                this.code = code;
                await DataStore.VisitCode(code); 
            
            } catch(Exception ex) {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    ShowWarning("Ошибка", ex.Message) ; 
                }); IsBusy = false; IsSkanner = false; return;  }

            Device.BeginInvokeOnMainThread(async () =>
            {
                ShowWarning("Заебись", "Чел ты крут мега крут");


            });


            //await Navigation.PushAsync(new UpcomingAppointmentsPage());
             await Shell.Current.GoToAsync("StatPage");
            IsSkanner = false;
           
            IsBusy = false;
            
        }


    }
}
