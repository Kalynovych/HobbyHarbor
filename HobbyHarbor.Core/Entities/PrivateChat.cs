using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyHarbor.Core.Entities
{
    public class PrivateChat
    {
        public int PrivateChatId { get; set; }

        public int AuthorId { get; set; }

        public User Author { get; set; }

        public int CompanionId { get; set; }

        public User Companion { get; set; }

        public IEnumerable<Message>? Messages { get; set; }
    }
}
