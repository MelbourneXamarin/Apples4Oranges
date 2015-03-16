using System;
using System.Collections.ObjectModel;
using System.Linq;
using Apples4Oranges.Model;

namespace Apples4Oranges.ViewModel
{
    internal static class AppViewModel
    {
        public static ObservableCollection<OfferEntry>OfferEntries { get; set; }
        public static ObservableCollection<OfferEntry> MyOfferEntries { get; set; }
        public static int CurrentUserId { get { return 1; } }
        public static OfferEntry SelectedOfferEntry { get; set; }
        static AppViewModel()
        {
            OfferEntries = new ObservableCollection<OfferEntry>
            {
                new OfferEntry
                {
                    Id = 1,
                    Name = "Apples",
                    Location = "Brunswick",
                    ImageLocation = "apples.jpg",
                    AvailableFrom = DateTime.Now,
                    AvailableTill = DateTime.Today.AddDays(2),
                    UserId = 10
                },
                new OfferEntry
                {
                    Id = 2,
                    Name = "Oranges",
                    Location = "Fitzroy",
                    ImageLocation = "oranges.jpg",
                    AvailableFrom = DateTime.Now.AddDays(1),
                    AvailableTill = DateTime.Today.AddDays(3),
                    UserId = 11
                }
            };


            MyOfferEntries = new ObservableCollection<OfferEntry>
            {
                new OfferEntry
                {
                    Id = 3,
                    Name = "Peaches",
                    Location = "Collingwood",
                    AvailableFrom = DateTime.Now,
                    AvailableTill = DateTime.Today.AddDays(2),
                    Views = 2,
                    Replies = 0,
                    UserId = 1
                },
                new OfferEntry
                {
                    Id = 4,
                    Name = "Lemons",
                    Location = "Fitzroy",
                    AvailableFrom = DateTime.Now.AddDays(100),
                    AvailableTill = DateTime.Today.AddDays(3),
                    Views = 16,
                    Replies = 2,
                    UserId = 1
                }
            };

            //OfferEntries = OfferEntries.Union(MyOfferEntries).ToObservableCollection();
        }
    }
}
