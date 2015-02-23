using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Apples4Oranges
{
    public partial class HomePage : TabbedPage
    {
        public HomePage()
        {
          InitializeComponent();
          this.Title = "Apples 4 Oranges";
            var viewModel = new HomePageViewModel();
          this.DataContext = viewModel;
          this.ItemSource = new string[] { "On Offer", "My Offers" };
          listViewOnOffer.ItemsSource = viewModel.OfferEntries;
          //this.ItemTemplate = new DataTemplate(() => { return new ContentPage(); }); 
        }
    }
}
