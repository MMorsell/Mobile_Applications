using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Freerider.Services;
using Freerider.Views;

namespace Freerider
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Xamarin.Forms.DependencyService.Get<INotificationManager>().Initialize();

            //DependencyService.Register<MockDataStore>();
            MainPage = new AllItemsPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}