using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Freerider.Models;
using Freerider.Views;
using Freerider.ViewModels;
using System.Collections.ObjectModel;

namespace Freerider.Views
{
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        private ObservableCollection<SubscribeModel> alreadyWatchedTrips = new ObservableCollection<SubscribeModel>();
        public ObservableCollection<SubscribeModel> AlreadyWatchedTrips { get { return alreadyWatchedTrips; } }

        public ItemsPage()
        {
            InitializeComponent();
            AlreadyWatchedTrips.Add(
                new SubscribeModel("Falun", "Borlänge")
                {
                    Id = 1,
                });
            AlreadyWatchedTrips.Add(
                new SubscribeModel("Falun", "Stockholm")
                {
                    Id = 2,
                });

            BindingContext = this;
        }

        private async void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (Item)layout.BindingContext;
            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
        }

        private async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ItemDetailPage()));
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
            var currentSubscribePost = (SubscribeModel)mi.CommandParameter;
            if (await DisplayAlert("Ta bort bevakning", $"Vill du verkligen ta bort bevakning:\n\n {currentSubscribePost.FormattedString}?", "Ja", "Nej"))
            {
                AlreadyWatchedTrips.Remove(AlreadyWatchedTrips.FirstOrDefault(sMod => sMod.Id.Equals(currentSubscribePost.Id)));
            };
        }
    }
}