
using QrPassMobail.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace QrPassMobail.Widgets
{


    public partial class WarningView : Popup
    {
        private bool dis;
        WarningViewModel vm;
        public WarningView()
        {
            InitializeComponent();
            vm = (WarningViewModel)BindingContext;
            MessagingCenter.Subscribe<WarningViewModel>(this, "ClosePopup", (sender) =>
            {
                if (!dis)
                {
                    dis = !dis;
                    Dismiss(this);
                }
            });

            _ = CloseP();
        }


        public async Task CloseP()
        {
            await Task.Delay(4000);
            if (!dis)
            {
                dis = !dis;
                Dismiss(this);
            }
        }

    }
}