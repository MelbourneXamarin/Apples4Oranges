using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apples4Oranges.Model
{
 
    public class ResponseMessage
    {
        /// <summary>
        /// The Id of a particular Message
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// The Response Wrapper linked to this message
        /// </summary>
        public long ResponseId { get; set; }

        /// <summary>
        /// Content of the message
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// TimeStamp the Message was posted
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Is there any Image associated with this Message?
        /// </summary>
        public int? ImageId { get; set; }
    }
}
