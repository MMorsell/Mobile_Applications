using Freerider.Models;
using Freerider.Services;
using Freerider.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Freerider.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllSubscribedTrips : ContentPage
    {
        private NotificationService _notificationService;
        private ItemsViewModel alreadyWatchedTrips;

        public AllSubscribedTrips()
        {
            InitializeComponent();
            _notificationService = new NotificationService();
        }

        private async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AddItemPage()));
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