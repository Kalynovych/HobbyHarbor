using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyHarbor.Core.Entities
{
    public class PrivateChat
    {
        public int AuthorId { get; set; }

        public int CompanionId { get; set; }

        public User Author { get; set; }

        public User Companion { get; set; }

        public ICollection<Message>? Messages { get; set; }
    }
}
