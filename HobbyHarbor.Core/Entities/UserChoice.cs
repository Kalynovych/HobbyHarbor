using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyHarbor.Core.Entities
{
    public class UserChoice
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int TargetId { get; set; }

        public User Target { get; set; }

        public bool IsLiked { get; set; } = false;

        public DateTime Time {  get; set; }
    }
}
