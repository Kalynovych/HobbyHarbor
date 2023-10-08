using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyHarbor.Core.Entities
{
    public class Post
    {
        public int Id { get; set; }

        public int CreatorId { get; set; }

        public User Creator { get; set; }

        public ICollection<PostInterest> PostInterests { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public ICollection<Comment>? Comments { get; set; }

        public string PostTitle { get; set; }

        public string PostContent { get; set; }

        public string? Attachment { get; set; }

        public int AttachmentTypeId { get; set; }

        public AttachmentType? AttachmentType { get; set; }

        public DateTime PublicationTime { get; set; }
    }
}
