namespace HobbyHarbor.Application.DTOs
{
    public class PrivateChatDTO
    {
		public int CreatorId { get; set; }

		public int CompanionId { get; set; }

        public string CreatorUsername { get; set; }

		public string CompanionUsername { get; set; }

		public string CompanionName { get; set; }

        public string CompanionProfileImage { get; set; }

        public DateTime? LastMessageTime { get; set; }

        public string? LastMessage { get; set; }

        public string? LastMessageAuthor { get; set; }
    }
}
