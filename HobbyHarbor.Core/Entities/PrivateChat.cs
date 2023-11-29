namespace HobbyHarbor.Core.Entities
{
    public class PrivateChat
    {
        public int CreatorId { get; set; }

        public int CompanionId { get; set; }

        public User Creator { get; set; }

        public User Companion { get; set; }

        public ICollection<PrivateMessage>? Messages { get; set; }
    }
}
