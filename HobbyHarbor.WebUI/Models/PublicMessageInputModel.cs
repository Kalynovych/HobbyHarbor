namespace HobbyHarbor.WebUI.Models
{
	public class PublicMessageInputModel
	{
		public int PublicChatId { get; set; }

		public string AuthorUsername { get; set; }

		public string MessageText { get; set; }

		public DateTime Time { get; set; }

		public int? ReplyMessageId { get; set; }

		public string? Attachment { get; set; }

		public int? AttachmentType { get; set; }
	}
}
