namespace HobbyHarbor.Core.Entities
{
	public class PublicMessage
	{
		public int Id { get; set; }

		public string MessageText { get; set; }

		public int MessageAuthorId { get; set; }

		public User MessageAuthor { get; set; }

		public DateTime Time { get; set; }

		public int? ReplyMessageId { get; set; }

		public PrivateMessage? ReplyTo { get; set; }

		public string? Attachment { get; set; }

		public int? AttachmentTypeId { get; set; }

		public AttachmentType? AttachmentType { get; set; }

		public int? PublicChatId { get; set; }

		public PublicChat? PublicChat { get; set; }
	}
}
