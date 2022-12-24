using QrPassMobail.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace QrPassMobail.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}