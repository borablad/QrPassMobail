using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ZXing;

namespace QrPassMobail.ViewModels
{
    public partial class ScannFullScreenViewModel:BaseViewModel
    {
        public ScannFullScreenViewModel()
        {

        }
        [RelayCommand]
        private void Handle_OnScanResult(Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                // await DisplayAlert("Scanned result", result.Text, "OK");
                var res = result.Text;//getResutl
            });
        }
    }
}
