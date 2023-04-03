using Android.Gestures;
using QrPassMobail.ViewModels;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace QrPassMobail.Views
{	
	public partial class NFCPage : ContentPage
	{
		NFCPageViewModel vm;
		public NFCPage ()
		{
			InitializeComponent ();
            vm = (NFCPageViewModel)BindingContext;
        }
		protected override void OnAppearing()
		{
			base.OnAppearing();
			vm.OnAppering();
		}
		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			vm.OnDisapiring();
		}
	}

}

