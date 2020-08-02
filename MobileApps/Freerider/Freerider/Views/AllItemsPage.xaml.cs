using System;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using Freerider.Models;
using Freerider.ViewModels;
using Freerider.Services;

namespace Freerider.Views
{
    [DesignTimeVisible(false)]
    public partial class AllItemsPage : ContentPage
    {
        private ItemsViewModel alreadyWatchedTrips;
        private NotificationService _notificationService;

        public AllItemsPage()
        {
            InitializeComponent();
            _notificationService = new NotificationService();
            BindingContext = alreadyWatchedTrips = new ItemsViewModel();
        }

        private async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AddItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //if (subscribeModels.Items.Count == 0)
            //    subscribeModels.IsBusy = true;
        }

        public async void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var currentSubscribePost = (ItemModel)mi.CommandParameter;
            if (await DisplayAlert("Ta bort bevakning", $"Vill du verkligen ta bort bevakning:\n\n {currentSubscribePost.FormattedString}?", "Ja", "Nej"))
            {
                alreadyWatchedTrips.Items.Remove(alreadyWatchedTrips.Items.FirstOrDefault(sMod => sMod.Id.Equals(currentSubscribePost.Id)));
            };
        }

        public void OnScheduleClick(object sender, EventArgs e)
        {
            string title = $"Local Notification #";
            string message = $"You have now received notifications!";
            _notificationService.SendNotification(title, message);
        }
    }
}