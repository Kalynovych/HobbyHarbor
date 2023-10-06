using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyHarbor.Core.Entities
{
    public class Profile
    {
        public int ProfileId { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public string Name { get; set; }

        public string? Surname { get; set; }

        public int Age { get; set; }

        public string? Country { get; set; }

        public string? Sex { get; set; }

        public DateTime Birthdate { get; set; }

        public string? About { get; set; }

        public IEnumerable<ProfileImage>? Images { get; set; }
    }
}
