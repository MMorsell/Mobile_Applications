﻿using System;
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
    public partial class AddItemPage : ContentPage
    {
        public AddItemPage()
        {
            InitializeComponent();

            BindingContext = new HertzFreeriderOptionsModel();
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            //Needs to be extracted to service
            //Freerider.Views.ItemsPage.AlreadyWatchedTrips.Add(new SubscribeModel("", "")
            //{
            //});
        }
    }
}