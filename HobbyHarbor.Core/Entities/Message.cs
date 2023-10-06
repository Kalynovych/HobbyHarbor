using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyHarbor.Core.Entities
{
    public class Message
    {
        public int MessageId { get; set; }

        public string MessageText { get; set; }

        public DateTime Time { get; set; }

        public Message? ReplyTo { get; set; }

        public bool IsPrivateChat { get; set; } = true;

        public string? PathToAttachment { get; set; }

        public int AttachmentTypeId { get; set; }

        public AttachmentType? AttachmentType { get; set; }

        public int PrivateChatId { get; set; }

        public PrivateChat? PrivateChat { get; set; }

        public int PublicChatId { get; set; }

        public PublicChat? PublicChat { get; set; }
    }
}
