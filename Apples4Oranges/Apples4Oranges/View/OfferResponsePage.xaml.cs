using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apples4Oranges.ViewModel;
using Xamarin.Forms;

namespace Apples4Oranges
{
    public partial class OfferResponsePage : ContentPage
    {
        public  OfferResponsePage()
        {
            InitializeComponent();
			listViewOnOffer.ItemsSource = AppViewModel.OfferResponses;

            listViewOnOffer.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return; // don't do anything if we just de-selected the row
                // do something with e.SelectedItem
                Model.OfferResponse selectedOfferResponse = e.SelectedItem as Model.OfferResponse;
                var messages = new ResponseMessagePage(selectedOfferResponse.Id);
                await Navigation.PushAsync(messages);

                ((ListView)sender).SelectedItem = null; // de-select the row
            };
        }		 
    }
}
