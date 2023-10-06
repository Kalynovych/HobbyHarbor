using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyHarbor.Core.Entities
{
    public class PublicChatInterest
    {
        public int PublicChatId { get; set; }

        public PublicChat PublicChat { get; set; }

        public int InterestId { get; set; }

        public Interest Interest { get; set; }
    }
}
