using System;
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
			listViewOnOffer.ItemsSource = viewModel.MyOfferEntries;
        }		 
    }
}
