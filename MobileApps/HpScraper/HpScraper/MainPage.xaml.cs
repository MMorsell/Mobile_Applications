using HpScraper.Helpers;
using HpScraper.Messages;
using System;
using Xamarin.Forms;
using HpScraper.Enums;

namespace HpScraper
{
    public partial class MainPage : ContentPage
    {
        private bool IsListeningToHpSale { get; set; } = false;
        private NotificationHelper _notificationHelper;
        private int _numberOfListens { get; set; } = 0;

        public MainPage()
        {
            _notificationHelper = new NotificationHelper();
            InitializeComponent();
            SetLabelValues();

            HandleReceivedMessages();
        }

        private void HandleReceivedMessages()
        {
            MessagingCenter.Subscribe<TickedEnum>(this, "TickedMessage", message =>
            {
                _numberOfListens++;
                this.numberOfListens.Text = $"Antal kontroller på sidan {_numberOfListens}";
                switch (message.MessageCode)
                {
                    case UpdateType.Major:
                        _notificationHelper.SendNotification("HP Web Scraper", "HP har öppnat försäljning av varan!");
                        break;

                    case UpdateType.Minor:
                        _notificationHelper.SendNotification("HP Web Scraper", "Ny förändring på produktsidan");
                        break;

                    case UpdateType.No_Difference:
                        //Do nothing
                        break;

                    default:
                        _notificationHelper.SendNotification("HP Web Scraper", $"Invalid enum! {message.MessageCode}");
                        break;
                }
            });

            MessagingCenter.Subscribe<TickedEnum>(this, "CancelledMessage", message =>
            {
                //Do nothing here
                //Device.BeginInvokeOnMainThread(() =>
                //{
                //    ticker.Text = "Cancelled";
                //});
            });
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            IsListeningToHpSale = !IsListeningToHpSale;
            SetLabelValues();
            StartOrStopWebScraperHelper();
        }

        private void StartOrStopWebScraperHelper()
        {
            switch (IsListeningToHpSale)
            {
                case true:
                    MessagingCenter.Send(new StartLongRunningTaskMessage(), "StartLongRunningTaskMessage");
                    break;

                case false:
                    MessagingCenter.Send(new StopLongRunningTaskMessage(), "StopLongRunningTaskMessage");
                    break;
            }
        }

        private void SetLabelValues()
        {
            switch (IsListeningToHpSale)
            {
                case true:
                    TopLabel.TextColor = Color.Green;
                    TopLabel.Text = Constants.TextValues.ListeningTxt;
                    ToggleButton.Text = Constants.TextValues.ListeningBtn;
                    break;

                case false:
                    TopLabel.TextColor = Color.Red;
                    TopLabel.Text = Constants.TextValues.NotlisteningTxt;
                    ToggleButton.Text = Constants.TextValues.NotlisteningBtn;
                    break;
            }
        }
    }
}