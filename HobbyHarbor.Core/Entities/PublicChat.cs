namespace HobbyHarbor.Core.Entities
{
    public class PublicChat
    {
        public int Id { get; set; }

        public ICollection<UsersPublicChat>? Participants { get; set; }

        public ICollection<PublicChatInterest> ChatInterests { get; set; }

        public ICollection<PublicMessage>? Messages { get; set; }

        public string ChatImage { get; set; }

        public string ChatTitle { get; set; }
    }
}
