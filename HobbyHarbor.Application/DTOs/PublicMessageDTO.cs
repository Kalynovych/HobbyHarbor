namespace HobbyHarbor.Application.DTOs
{
	public class PublicMessageDTO : MessageDTO
	{
		public int PublicChatId { get; set; }

		public ICollection<string> Participants { get; set; }
	}
}
