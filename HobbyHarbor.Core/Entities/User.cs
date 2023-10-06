using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyHarbor.Core.Entities
{
    public class User
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Profile Profile { get; set; }

        public bool IsPremium { get; set; } = false;

        public IEnumerable<UserChoice>? Choices { get; set; }

        public IEnumerable<PrivateChat>? PrivateChats { get; set; }

        public IEnumerable<UsersPublicChat>? PublicChats { get; set; }

        public IEnumerable<Comment>? Comments { get; set; }

        public IEnumerable<Post>? Posts { get; set; }

        public IEnumerable<Payment>? Payments { get; set; }

        public IEnumerable<UserInterest> UserInterests { get; set; }
    }
}
