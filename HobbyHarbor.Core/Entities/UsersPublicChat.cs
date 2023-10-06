using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyHarbor.Core.Entities
{
    public class UsersPublicChat
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int PublicChatId { get; set; }

        public PublicChat PublicChat { get; set; }
    }
}
