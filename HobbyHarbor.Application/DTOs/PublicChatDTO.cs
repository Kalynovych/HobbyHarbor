namespace HobbyHarbor.Application.DTOs
{
	public class PublicChatDTO
	{
		public int Id { get; set; }

		public string ChatTitle { get; set; }

		public string ChatImage { get; set; }

		public DateTime? LastMessageTime { get; set; }

		public string? LastMessage { get; set; }

		public string? LastMessageAuthor { get; set; }

		public string? LastMessageAuthorName { get; set; }

		public ICollection<InterestDTO> Interests { get; set; }
	}
}
