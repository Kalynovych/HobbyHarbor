using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyHarbor.Core.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }

        public int AuthorId { get; set; }

        public User Author { get; set; }

        public string Text { get; set; }

        public int PostId { get; set; }

        public Post Post { get; set; }

        public Comment? ReplyTo {  get; set; }

        public DateTime Time {  get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }
    }
}
