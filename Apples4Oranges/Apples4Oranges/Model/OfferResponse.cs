using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apples4Oranges.Model
{
    /// <summary>
    /// Wrapper to the chat between the Original Poster and Responder
    /// </summary>
    class OfferResponse
    {
        /// <summary>
        /// Id of this OfferResponse
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The Offer Entry this response is linked to
        /// </summary>
        public long OfferEntryId { get; set; }

        /// <summary>
        /// ID of the User Responding to the offer
        /// Cannot be the same as the Original Poster
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The UserName of the Responding / interested User
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// A glimpse of the latest msg to show in the Wrapper
        /// </summary>
        public string LatestMessage { get; set; }

        /// <summary>
        /// DateTime the Response was initially created
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// The last responded datetime for this offerEntry
        /// </summary>
        public DateTime LastResponded { get; set; }

        /// <summary>
        /// Has this been marked as a favourite
        /// </summary>
        public bool IsStarred { get; set; }

        /// <summary>
        /// Is this Message being Seen by the Original Poster?
        /// </summary>
        public bool IsRead { get; set; }

        public string HeaderText
        {
            get { return String.Format("{0}{1}{1}{2}", UserName.PadRight(50,' '), "\t", LastResponded.ToString("d MMM")); }
        }

    }
}
