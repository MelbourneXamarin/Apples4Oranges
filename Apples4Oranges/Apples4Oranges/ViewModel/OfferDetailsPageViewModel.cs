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

        public bool IsOwnOffer
        {
            get { return _offerEntry.Id > 0 && _offerEntry.Owner.UserId == AppViewModel.CurrentUserId; }
        }

        public bool IsNewOffer
        {
            get { return _offerEntry.Id <= 0; }
        }
    }
}
