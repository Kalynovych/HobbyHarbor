using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyHarbor.Core.Entities
{
    public class PostInterest
    {
        public int PostId { get; set; }

        public int InterestId { get; set; }
        
        public Post Post { get; set; }

        public Interest Interest { get; set; }
    }
}
