using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apples4Oranges.ViewModel;
using Xamarin.Forms;

namespace Apples4Oranges
{
    public partial class OfferDetailsPage : ContentPage
    {
        public  OfferDetailsPage()
        {
            InitializeComponent();
            var viewModel = new OfferDetailsPageViewModel();
            viewModel.OfferEntry = AppViewModel.SelectedOfferEntry;
            this.BindingContext = viewModel;
        }		 
    }
}
