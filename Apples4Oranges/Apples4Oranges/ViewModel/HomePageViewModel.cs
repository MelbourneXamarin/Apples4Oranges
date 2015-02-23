using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apples4Oranges.ViewModel
{
    internal class HomePageViewModel
    {
        public static ObservableCollection<OfferEntry> OfferEntries { get; set; }

        static HomePageViewModel()
        {
            OfferEntries = new ObservableCollection<OfferEntry>();
            OfferEntries.Add(new OfferEntry {Name = "Apples", Location ="Brunswick", AvailableFrom = DateTime.Now, AvailableTill = DateTime.Today.AddDays(2) });
            OfferEntries.Add(new OfferEntry {Name = "Oranges", Location ="Fitzroy", AvailableFrom = DateTime.Now.AddDays(1), AvailableTill = DateTime.Today.AddDays(3) });
            
        }
    }

    
}
