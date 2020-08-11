using HpScraper.Helpers;
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
        private bool IsListeningToHpSale { get; set; }
        private NotificationHelper _notificationHelper;

        public MainPage()
        {
            _notificationHelper = new NotificationHelper();
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
        }
    }
}