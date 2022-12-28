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

namespace QrPassMobail.ViewModels
{
    public partial class MainPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private bool isSkanner = true;

      public MainPageViewModel()
        {
            
        //    ShowWarning("Error", "havno");
        }
       public async Task ResultScan(int code)
        {
           
            IsBusy = true;
            IsSkanner = false;
             IsSkanner = true;
            try {  await DataStore.VisitCode(code); } catch {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    ShowWarning("Error", "chel");
                }); return; IsSkanner = true; }
            Device.BeginInvokeOnMainThread(async () =>
            {
                ShowWarning("Susseful", "chel");
            });

            IsSkanner = true;
           
            IsBusy = false;
            
        }


    }
}
