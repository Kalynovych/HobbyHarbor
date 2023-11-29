namespace HobbyHarbor.WebUI.Models
{
	public class PrivateMessageInputModel
	{
		public int CreatorId { get; set; }

		public int CompanionId { get; set; }

		public string AuthorUsername { get; set; }

		public string MessageText { get; set; }

		public DateTime Time { get; set; }

		public int? ReplyMessageId { get; set; }

		public string? Attachment { get; set; }

		public int? AttachmentType { get; set; }
	}
}
