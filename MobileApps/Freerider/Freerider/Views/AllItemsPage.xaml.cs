using System;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using Freerider.Models;
using Freerider.ViewModels;
using Freerider.Services;
using System.Threading.Tasks;

namespace Freerider.Views
{
    [DesignTimeVisible(false)]
    public partial class AllItemsPage : ContentPage
    {
        private ItemsViewModel _currentTripsOnHertzFreerider;

        public AllItemsPage()
        {
            InitializeComponent();
            BindingContext = _currentTripsOnHertzFreerider = new ItemsViewModel();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AllSubscribedTrips()));
        }
    }
}