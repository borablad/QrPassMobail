using QrPassMobail.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Mobile;

namespace QrPassMobail.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel vm;
        public MainPage()
        {
            InitializeComponent();
            vm = (MainPageViewModel)BindingContext;

        }

        private async void _scanView_OnScanResult(ZXing.Result result)
            {
            int code=0;
            try
            {
                code = Int32.Parse(result.Text.ToString());
            }
            catch
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    vm.ShowWarning("Ошибка", "Qr не распознан");
                });
                return;
               // await Task.Delay(1000 - 7);
            }
           await vm.ResultScan(code);
        }
    }
}