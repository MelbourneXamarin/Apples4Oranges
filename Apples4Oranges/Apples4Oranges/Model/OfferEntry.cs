using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apples4Oranges.Model
{
    public class OfferEntry
    {
        /// <summary>
        /// ForeignKey to the User who owns this offer
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// ForeignKey to the User who owns this offer
        /// </summary>
        public UserProfile Owner { get; set; }
        /// <summary>
        /// Name of the product or service - offer name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Name of the suburb where the offer is available
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Physical path of the Image (if available ) in the server
        /// </summary>
        public string ImageLocation { get; set; }

        /// <summary>
        ///Since when is the offer available 
        /// </summary>
        public DateTime AvailableFrom { get; set; }

        /// <summary>
        /// Since when is the offer available till
        /// </summary>
        public DateTime AvailableTill { get; set; }

        /// <summary>
        /// More info about whats on offer
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// What do we want in xchange for this offerEntry
        /// </summary>
        public List<string> BarterList { get; set; }

        /// <summary>
        /// Just a flag to mark Complete / Active
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// How many views on this offer
        /// </summary>
        public int Views { get; set; }

        /// <summary>
        /// How many responses for this offer
        /// </summary>
        public int Replies { get; set; }

        public string ViewsAndReplies
        {
            get { return string.Format("{0} views {1} replies", Views, Replies); }
        }

        public string OfferDetailText
        {
            get { return string.Format("{0} - expiring on {1}", Location, AvailableTill.ToString("M"));
            }
        }

        public string MyOfferDetailText
        {
            get
            {
                return string.Format("Ends {0} {1}", AvailableTill.ToString("M"),ViewsAndReplies.PadLeft(40,' '));
            }
        }
     }
}
