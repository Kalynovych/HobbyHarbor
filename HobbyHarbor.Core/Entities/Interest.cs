namespace HobbyHarbor.Core.Entities
{
    public class Interest
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public InterestCategory Category { get; set; }

        public string Title { get; set; }

        public ICollection<UserInterest>? UserInterests { get; set; }

        public ICollection<PostInterest>? PostInterests { get; set; }

        public ICollection<PublicChatInterest>? PublicChatInterests { get; set; }
    }
}
