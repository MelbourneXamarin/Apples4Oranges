﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apples4Oranges.ViewModel;
using Xamarin.Forms;

namespace Apples4Oranges
{
    public partial class MyOfferPage : ContentPage
    {
        public  MyOfferPage()
        {
            InitializeComponent();
			var viewModel = new HomePageViewModel ();
            listViewMyOffer.ItemsSource = viewModel.MyOfferEntries;
            listViewMyOffer.ItemSelected += async(sender, e) =>
            {
                if (e.SelectedItem == null) 
                    return; // don't do anything if we just de-selected the row
                // do something with e.SelectedItem
                var details = new OfferDetailsPage();
                await Navigation.PushModalAsync(details);

                ((ListView)sender).SelectedItem = null; // de-select the row
            };
            postNewOfferButton.Clicked += PostNewOfferButton_Click;
        }		 

        private async void PostNewOfferButton_Click(object sender, EventArgs e)
        {
            var details = new OfferDetailsPage();
            await Navigation.PushModalAsync(details);
        }
    }
}
