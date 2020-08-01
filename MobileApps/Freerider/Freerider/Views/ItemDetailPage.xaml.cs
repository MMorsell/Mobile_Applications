using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Freerider.Models;
using Freerider.ViewModels;

namespace Freerider.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        private ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = new HertzFreeriderOptionsModel();
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            BindingContext = new HertzFreeriderOptionsModel();
        }
    }
}