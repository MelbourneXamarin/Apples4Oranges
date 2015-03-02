using System;
using System.Collections.ObjectModel;
using Apples4Oranges.Model;

namespace Apples4Oranges.ViewModel
{
    internal class HomePageViewModel
    {
        public ObservableCollection<OfferEntry>OfferEntries { get; set; }
        public ObservableCollection<OfferEntry> MyOfferEntries { get; set; }
        public HomePageViewModel()
        {
            OfferEntries = new ObservableCollection<OfferEntry>
            {
                new OfferEntry
                {
                    Name = "Apples",
                    Location = "Brunswick",
                    ImageLocation = "apples.jpg",
                    AvailableFrom = DateTime.Now,
                    AvailableTill = DateTime.Today.AddDays(2)
                },
                new OfferEntry
                {
                    Name = "Oranges",
                    Location = "Fitzroy",
                    ImageLocation = "oranges.jpg",
                    AvailableFrom = DateTime.Now.AddDays(1),
                    AvailableTill = DateTime.Today.AddDays(3)
                }
            };


            MyOfferEntries = new ObservableCollection<OfferEntry>
            {
                new OfferEntry
                {
                    Name = "Peaches",
                    Location = "Collingwood",
                    AvailableFrom = DateTime.Now,
                    AvailableTill = DateTime.Today.AddDays(2)
                },
                new OfferEntry
                {
                    Name = "Lemons",
                    Location = "Fitzroy",
                    AvailableFrom = DateTime.Now.AddDays(100),
                    AvailableTill = DateTime.Today.AddDays(3)
                }
            };
        }
    }

    
}
