using System;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
namespace QrPassMobail.ViewModels
{
	public partial class NFCPageViewModel:BaseViewModel
	{

		[ObservableProperty]
		private bool nFCScan = true;

		public NFCPageViewModel()
		{
		}

		[RelayCommand]
		public async void BackToQR()
		{
			await AppShell.Current.Navigation.PopAsync();
		} 
	}
}

