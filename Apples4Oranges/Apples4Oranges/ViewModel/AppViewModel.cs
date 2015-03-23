using System;
using System.Collections.ObjectModel;
using System.Linq;
using Apples4Oranges.Model;
using System.Collections.Generic;

namespace Apples4Oranges.ViewModel
{
    public static class AppViewModel
    {
        public static ObservableCollection<OfferEntry>OfferEntries { get; set; }
        public static ObservableCollection<OfferEntry> MyOfferEntries { get; set; }

        public static ObservableCollection<OfferResponse> OfferResponses { get; set; }
        public static ObservableCollection<ResponseMessage> ResponseMessages { get; set; }
        public static List<UserProfile> UserProfiles { get; set; }

        public static int CurrentUserId { get { return 1; } }
        public static OfferEntry SelectedOfferEntry { get; set; }
        static AppViewModel()
        {
            UserProfiles = new List<UserProfile>
            {
                new UserProfile
                {
                    UserHandle="Da Wolf",
                    UserId = 1
                },
                new UserProfile
                {
                    UserHandle = "Viking99",
                    UserId = 2
                },
                new UserProfile
                {
                    UserHandle = "the_Earth",
                    UserId = 3
                },
                new UserProfile
                {
                    UserHandle = "D_Boss",
                    UserId = 4
                }

            };

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
                    Owner = UserProfiles.First(x=> x.UserId ==3)
                },
                new OfferEntry
                {
                    Id = 2,
                    Name = "Oranges",
                    Location = "Fitzroy",
                    ImageLocation = "oranges.jpg",
                    AvailableFrom = DateTime.Now.AddDays(1),
                    AvailableTill = DateTime.Today.AddDays(3),
                    Owner = UserProfiles.First(x=> x.UserId ==4)
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
                    Owner = UserProfiles.First(x=> x.UserId ==1)
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
                    Owner = UserProfiles.First(x=> x.UserId ==1)
                }
            };

            foreach (OfferEntry offer in MyOfferEntries)
                OfferEntries.Add(offer);

            OfferResponses = new ObservableCollection<OfferResponse>
            {
                new OfferResponse {
                    Id=1,
                    OfferEntryId = 3,
                    RespondingUser = UserProfiles.First(x=>x.UserId == 2),
                    
                    LatestMessage = "Hi, I am interested to trade...",
                    Created = DateTime.Now.AddDays(-1),
                    LastResponded = DateTime.Now.AddDays(-1),
                    IsRead = true,
                    IsStarred = false
                },
                 new OfferResponse {
                    Id=2,
                    OfferEntryId = 3,
                    RespondingUser = UserProfiles.First(x=>x.UserId == 3),
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
                    Response = OfferResponses.FirstOrDefault(o=> o.Id == 1),
                    User = UserProfiles.FirstOrDefault(x=>x.UserId == 2),
                    Body = "Hi, I am interested to trade my Apples for your Peaches." + 
                    "I have two baskets full of Pink Ladies. Buzz me back if interested",
                    Timestamp = DateTime.Now.AddDays(-1)
                },
                new ResponseMessage{
                    Id = 1,
                    Response = OfferResponses.FirstOrDefault(o=> o.Id == 1),
                    Body = "Nice. I love Apples. When do you want to do the trade?" + 
                    "Please get back to me by tomorrow 6 PM.",
                    Timestamp = DateTime.Now.AddDays(-1),
                    User = UserProfiles.FirstOrDefault(x=>x.UserId == 1)
                },
                 new ResponseMessage{
                    Id = 1,
                    Response = OfferResponses.FirstOrDefault(o=> o.Id == 2),
                    Body = "Hi, I got muffins bro... Can you give em Peaches for Free Hugs?" + 
                    "Ping back if you are a kind soul.",
                    Timestamp = DateTime.Today.AddHours(10.5),
                    User = UserProfiles.FirstOrDefault(x=>x.UserId == 4),
                },
                 new ResponseMessage{
                    Id = 1,
                    Response = OfferResponses.FirstOrDefault(o=> o.Id == 2),
                    Body = "Hey buddy, I cant give em all, but can give a handful. Interested?",
                   
                    Timestamp = DateTime.Today.AddHours(10.5),
                    User = UserProfiles.FirstOrDefault(x=>x.UserId == 1),
                }
            };
        }
    }
}
