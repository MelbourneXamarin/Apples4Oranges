using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apples4Oranges.ViewModel;
using Xamarin.Forms;

namespace Apples4Oranges
{
    public partial class HomePage
    {
        public HomePage()
        {
			InitializeComponent ();
			Title = "Apples 4 Oranges";
            //ItemsSource = new string[] { "On Offer", "My Offers" };
            //ItemTemplate = new DataTemplate (() => new OfferPage ()); 

            Children.Add(new OfferPage());
            Children.Add(new MyOfferPage());
        }
    }
}
