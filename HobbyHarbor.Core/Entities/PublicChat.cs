using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyHarbor.Core.Entities
{
    public class PublicChat
    {
        public int PublicChatId { get; set; }

        public IEnumerable<UsersPublicChat>? Participants { get; set; }

        public IEnumerable<Interest> ChatInterests { get; set; } = Enumerable.Empty<Interest>();

        public IEnumerable<Message>? Messages { get; set; }

        public int AuthorId { get; set; }

        public User Author { get; set; }

        public string ChatTitle { get; set; }
    }
}
