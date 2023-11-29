namespace HobbyHarbor.Application.DTOs
{
    public class PrivateMessageDTO : MessageDTO
    {
		public int CreatorId { get; set; }

		public int CompanionId { get; set; }

		public string CompanionUsername { get; set; }
	}
}
