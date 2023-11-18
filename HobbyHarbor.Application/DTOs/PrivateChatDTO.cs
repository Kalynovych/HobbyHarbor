namespace HobbyHarbor.Application.DTOs
{
    public class PrivateChatDTO
    {
        public string CompanionName { get; set; }

        public string CompanionProfileImage { get; set; }

        public DateTime LastMessageTime { get; set; }

        public string LastMessage { get; set; }

        public string LastMessageAuthor { get; set; }
    }
}
