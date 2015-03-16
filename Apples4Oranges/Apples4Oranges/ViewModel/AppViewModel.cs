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

        public static ObservableCollection<OfferResponse> OfferResponses { get; set; }
        public static ObservableCollection<ResponseMessage> ResponseMessages { get; set; }

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
                    ImageLocation = "icon.png",
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
                    ImageLocation = "icon.png",
                    AvailableFrom = DateTime.Now.AddDays(100),
                    AvailableTill = DateTime.Today.AddDays(3),
                    Views = 16,
                    Replies = 2,
                    UserId = 1
                }
            };

            foreach (OfferEntry offer in MyOfferEntries)
                OfferEntries.Add(offer);

            OfferResponses = new ObservableCollection<OfferResponse>
            {
                new OfferResponse {
                    Id=1,
                    OfferEntryId = 3,
                    UserId = 2,
                    UserName = "Vikings99",
                    LatestMessage = "Hi, I am interested to trade...",
                    Created = DateTime.Now.AddDays(-1),
                    LastResponded = DateTime.Now.AddDays(-1),
                    IsRead = true,
                    IsStarred = false
                },
                 new OfferResponse {
                    Id=2,
                    OfferEntryId = 3,
                    UserId = 22,
                    UserName = "the_Earth",
                    LatestMessage = "Hi, I got muffins...",
                    Created = DateTime.Today.AddHours(10.5),
                    LastResponded = DateTime.Today.AddHours(10.5),
                    IsRead = true,
                    IsStarred = false
                }
            };

            ResponseMessages = new ObservableCollection<ResponseMessage>
            {
                new ResponseMessage{
                    Id = 1,
                    ResponseId = 1,
                    Body = "Hi, I am interested to trade my Apples for your Peaches." + 
                    "I have two baskets full of Pink Ladies. Buzz me back if interested",
                    Timestamp = DateTime.Now.AddDays(-1)
                },
                 new ResponseMessage{
                    Id = 1,
                    ResponseId = 2,
                    Body = "Hi, I got muffins bro... Can you give em Peaches for Free Hugs?" + 
                    "Ping back if you are a kind soul.",
                    Timestamp = DateTime.Today.AddHours(10.5)
                }
            };
        }
    }
}
