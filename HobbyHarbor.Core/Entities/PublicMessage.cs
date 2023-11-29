namespace HobbyHarbor.Core.Entities
{
	public class PublicMessage : Message
	{
		public int PublicChatId { get; set; }

		public PublicChat PublicChat { get; set; }
	}
}
