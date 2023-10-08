using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyHarbor.Core.Entities
{
    public class AttachmentType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; }

        public ICollection<Message> Messages { get; set; }
    }
}
