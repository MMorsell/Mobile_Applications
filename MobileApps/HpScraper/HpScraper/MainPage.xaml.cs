using Android.Content;
using HpScraper.Helpers;
using HpScraper.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HpScraper
{
    public partial class MainPage : ContentPage
    {
        private bool IsListeningToHpSale { get; set; } = false;
        private NotificationHelper _notificationHelper;

        public MainPage()
        {
            _notificationHelper = new NotificationHelper();
            InitializeComponent();
            SetLabelValues();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            IsListeningToHpSale = !IsListeningToHpSale;
            SetLabelValues();
            StartOrStopWebScraperHelper();
        }

        private void StartOrStopWebScraperHelper()
        {
            //switch (IsListeningToHpSale)
            //{
            //    case true:
            //        Intent int = new Intent(this.BindingContext, typeof(XamarinService));

            //        break;

            //    case false:
            //        Intent int = new Intent(this, typeof(XamarinService));

            //        break;
            //}
            WebscraperHelper.GetNewUpdate();
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