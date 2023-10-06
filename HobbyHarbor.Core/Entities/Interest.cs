using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyHarbor.Core.Entities
{
    public class Interest
    {
        public int InterestId { get; set; }

        public int CategoryId { get; set; }

        public InterestCategory Category { get; set; }

        public string Title { get; set; }

        public IEnumerable<UserInterest>? UserInterests { get; set; }

        public IEnumerable<PostInterest>? PostInterests { get; set; }

        public IEnumerable<PublicChatInterest>? PublicChatInterests { get; set; }
    }
}
