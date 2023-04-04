using System;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using Plugin.NFC;
using Xamarin.Forms;
//using static Android.Icu.Text.TimeZoneFormat;
using System.Threading.Tasks;
//using Android.Nfc;

namespace QrPassMobail.ViewModels
{
	public partial class NFCPageViewModel:BaseViewModel
	{

		[ObservableProperty]
		private bool nFCScan = true, deviceIsListening;

        private bool isDeviceiOs = Device.RuntimePlatform == Device.iOS;

        private bool eventsAlreadySubscribed;

        private bool _nfcIsEnabled;
        public bool NfcIsEnabled
        {
            get => _nfcIsEnabled;
            set
            {
                _nfcIsEnabled = value;
                OnPropertyChanged(nameof(NfcIsEnabled));
                OnPropertyChanged(nameof(NfcIsDisabled));
            }
        }
        public bool NfcIsDisabled => !NfcIsEnabled;
        private TagInfo tmpData;

        [ObservableProperty]
        private NFCNdefTypeFormat type;

        public NFCPageViewModel()
		{

		}
      
        internal async void OnAppering()
		{
            SubscribeEvents();

            // await StartListeningIfNotiOS();

            Publish(NFCNdefTypeFormat.WellKnown);
        }

        private async Task p()
        {
            while (NFCScan)
            {
                
            }

        }
        private async Task Publish(NFCNdefTypeFormat? typ = null)
        {
            await StartListeningIfNotiOS();
            try
            {
                Type = NFCNdefTypeFormat.WellKnown;

               

                if (typ.HasValue) Type = typ.Value;
                CrossNFC.Current.StartPublishing(!typ.HasValue);
            }
            catch (Exception ex)
            {
                await ShowToast(ex.Message);
            }
            
          
        }
       private async Task StartListeningIfNotiOS()
        {
            if (isDeviceiOs)
                return;
            await BeginListening();
        }
        private  async Task BeginListening()
        {
            try
            {
                CrossNFC.Current.StartListening();
            }
            catch (Exception ex)
            {
                await ShowToast(ex.Message);
            }
        }
       
        private  async void Current_OnNfcStatusChanged(bool isEnabled)
        {
            NfcIsEnabled = isEnabled;
            ShowWarning("NFC", $"{(isEnabled ? "Включен" : "Отключен")}");
            
        }

        private async void Current_OnTagDiscovered(ITagInfo tagInfo, bool format)
        {
            if (!CrossNFC.Current.IsWritingTagSupported)
            {
                await ShowToast("Запись не поддерживается устройством");
                return;
            }

            try
            {

                var writePayload = "Sasi";

                var record = new NFCNdefRecord
                {
                    TypeFormat = NFCNdefTypeFormat.Unknown,
                    MimeType = "text/plain",
                    Payload = NFCUtils.EncodeToByteArray(writePayload)
                };
                if (!format && record == null)
                    throw new Exception("Record cant be null");

                tagInfo.Records = new[] { record };

                if (format)
                    CrossNFC.Current.ClearMessage(tagInfo);
                else
                {
                    CrossNFC.Current.PublishMessage(tagInfo, false);
                }
            }
            catch (Exception ex)
            {
                await ShowToast(ex.Message);
            }
        }
       
        private async void Current_OnMessagePublished(ITagInfo tagInfo)
        {
            try
            {

                CrossNFC.Current.StopPublishing();
                if (tagInfo.IsEmpty)
                    await ShowToast("Операция тега форматирования прошла успешно");
                else
                    await ShowToast("Запись тега прошла успешно");
            }
            catch (Exception ex)
            {
                await ShowToast(ex.Message);
            }
        }
       private async void Current_OnMessageReceived(ITagInfo tagInfo)
        {
            if (tagInfo == null)
            {
                await ShowToast("No tag found");
                return;
            }

            // Customized serial number
            var identifier = tagInfo.Identifier;
            var serialNumber = NFCUtils.ByteArrayToHexString(identifier, ":");
            var title = !string.IsNullOrWhiteSpace(serialNumber) ? $"Tag [{serialNumber}]" : "Tag Info";

            if (!tagInfo.IsSupported)
            {
                 ShowWarning("Unsupported tag (app)", title);
            }
            else if (tagInfo.IsEmpty)
            {
                ShowWarning("Empty tag", title);
            }
            else
            {
                 var first = tagInfo.Records[0];
                ShowWarning(GetMessage(first), title);
                Current_OnTagDiscovered(tagInfo, false);

            }
        }
        private void SubscribeEvents()
        {
            if (eventsAlreadySubscribed)
                return;

            eventsAlreadySubscribed = true;
            /*
                        CrossNFC.Current.OnMessageReceived += Current_OnMessageReceived;
                       
                        CrossNFC.Current.OnTagDiscovered += Current_OnTagDiscovered;*/
            CrossNFC.Current.OnNfcStatusChanged += Current_OnNfcStatusChanged;
            CrossNFC.Current.OnTagDiscovered += Current_OnTagDiscovered;
            CrossNFC.Current.OnMessagePublished += Current_OnMessagePublished;
            CrossNFC.Current.OnMessageReceived += Current_OnMessageReceived;
            /*    CrossNFC.Current.OnTagListeningStatusChanged += Current_OnTagListeningStatusChanged;*/

            /* if (isDeviceiOs)
                 CrossNFC.Current.OniOSReadingSessionCancelled += Current_OniOSReadingSessionCancelled;*/
        }  
        private void UnsubscribeEvents()
        {

     
            CrossNFC.Current.OnNfcStatusChanged -= Current_OnNfcStatusChanged;
            CrossNFC.Current.OnTagDiscovered -= Current_OnTagDiscovered;
            CrossNFC.Current.OnMessagePublished -= Current_OnMessagePublished;

        }

        string GetMessage(NFCNdefRecord record)
        {
            var message = $"Message: {record.Message}";
            message += Environment.NewLine;
            message += $"RawMessage: {System.Text.Encoding.UTF8.GetString(record.Payload)}";
            message += Environment.NewLine;
            message += $"Type: {record.TypeFormat}";

            if (!string.IsNullOrWhiteSpace(record.MimeType))
            {
                message += Environment.NewLine;
                message += $"MimeType: {record.MimeType}";
            }

            return message;
        }
        [RelayCommand]
		public async void BackToQR()
		{
            UnsubscribeEvents();
            NFCScan = false;
            await AppShell.Current.Navigation.PopAsync();
		} 

        internal void OnDisapiring()
        {
            NFCScan = false;
            UnsubscribeEvents();
        }
	}
}

