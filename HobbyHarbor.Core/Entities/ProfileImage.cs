using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyHarbor.Core.Entities
{
    public class ProfileImage
    {
        public int ProfileImageId { get; set; }

        public int ProfileId { get; set; }

        public Profile Profile { get; set; }
        
        public string PathToImage { get; set; }
    }
}
