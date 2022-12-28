using CommunityToolkit.Mvvm.ComponentModel;
using QrPassMobail.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.CommunityToolkit.ObjectModel;

namespace QrPassMobail.ViewModels
{
    public partial class StatPageViewModel : BaseViewModel
    {
        public ObservableRangeCollection<Visits> Visits { get; set; } = new ObservableRangeCollection<Visits>();
        public List<Visits> tempVisits { get; set; } = new List<Visits>();
        public StatPageViewModel()
        {

        }
        internal async void OnApperring()
        {
            try
            {
                tempVisits= await DataStore.getMyVisits();

            }
            catch
            {
                ShowWarning("Error", "need inet");

            }

            Visits.ReplaceRange(tempVisits);
           

        }

    }
}
