namespace HobbyHarbor.Core.Entities
{
    public class UsersPublicChat
    {
        public int UserId { get; set; }

        public int PublicChatId { get; set; }
        
        public User User { get; set; }

        public PublicChat PublicChat { get; set; }

        public bool IsCreator { get; set; }
    }
}
