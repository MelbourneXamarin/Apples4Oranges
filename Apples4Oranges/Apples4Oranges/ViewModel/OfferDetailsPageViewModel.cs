using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apples4Oranges.ViewModel
{
    class OfferDetailsPageViewModel : BaseViewModel
    {
        private Model.OfferEntry _offerEntry;
        public Model.OfferEntry OfferEntry
        {
            get { return _offerEntry; }
            set
            {
                if (value != null)
                {
                    _offerEntry = value;
                    OnPropertyChanged("OfferEntry");
                }
            }
        }

        public string ViewsAndReplies
        {
            get {  return _offerEntry.Views +" views " +  _offerEntry.Replies +" Replies";}
        }

        public bool IsOwnOffer
        {
            get { return _offerEntry.Id > 0 && _offerEntry.UserId == AppViewModel.CurrentUserId; }
        }

        public bool IsNewOffer
        {
            get { return _offerEntry.Id <= 0; }
        }


    }
}
