﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyHarbor.Core.Entities
{
    public class PublicChat
    {
        public int Id { get; set; }

        public ICollection<UsersPublicChat>? Participants { get; set; }

        public ICollection<PublicChatInterest> ChatInterests { get; set; }

        public ICollection<Message>? Messages { get; set; }

        public string ChatTitle { get; set; }
    }
}
