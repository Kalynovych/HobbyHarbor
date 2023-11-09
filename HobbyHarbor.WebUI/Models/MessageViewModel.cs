namespace HobbyHarbor.WebUI.Models
{
	public class MessageViewModel
	{
		public int Id { get; set; }

		public int MessageAuthorId { get; set; }

		public string MessageText { get; set; }

		public string AuthorName { get; set; }

		public string AuthorProfileImage { get; set; }

		public DateTime Time { get; set; }

		public int? ReplyMessageId { get; set; }

		public string? Attachment {  get; set; }

		public int? AttachmentType { get; set; }
	}
}
