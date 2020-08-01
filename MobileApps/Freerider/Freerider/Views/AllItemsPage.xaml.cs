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
    public partial class AllItemsPage : ContentPage
    {
        private ItemsViewModel alreadyWatchedTrips;

        public AllItemsPage()
        {
            InitializeComponent();

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
    }
}