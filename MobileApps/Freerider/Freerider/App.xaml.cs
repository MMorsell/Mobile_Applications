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

            DependencyService.Register<MockDataStore>();
            MainPage = new ItemDetailPage();
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