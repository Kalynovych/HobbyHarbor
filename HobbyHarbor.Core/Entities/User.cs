namespace HobbyHarbor.Core.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public Profile Profile { get; set; }

        public bool IsPremium { get; set; } = false;

        public DateTime LastActivity { get; set; }

        public ICollection<CommentsReaction>? CommentsReactions { get; set; }

		public ICollection<PostsReaction>? PostsReactions { get; set; }

		public ICollection<UserChoice>? Choices { get; set; }

        public ICollection<PrivateMessage> PrivateMessages { get; set; }

        public ICollection<PublicMessage> PublicMessages { get; set; }

        public ICollection<PrivateChat>? PrivateChats { get; set; }

        public ICollection<UsersPublicChat>? PublicChats { get; set; }

        public ICollection<Comment>? Comments { get; set; }

        public ICollection<Post>? Posts { get; set; }

        public ICollection<Payment>? Payments { get; set; }

        public ICollection<UserInterest> UserInterests { get; set; }
    }
}
