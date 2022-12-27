using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QrPassMobail.ViewModels
{

    public partial class WarningViewModel : BaseViewModel
    {
        #region Fields
        [ObservableProperty]
        private string message;
        #endregion

        public WarningViewModel()
        {

        }

        [RelayCommand]
        private async Task CloseTapped()
        {
            MessagingCenter.Send(this, "ClosePopup");
            await Task.CompletedTask;
        }
    }

}