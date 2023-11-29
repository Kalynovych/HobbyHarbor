namespace HobbyHarbor.Core.Entities
{
	public abstract class Message
	{
		public int Id { get; set; }

		public string MessageText { get; set; }

		public int MessageAuthorId { get; set; }

		public User MessageAuthor { get; set; }

		public DateTime Time { get; set; }

		public int? ReplyMessageId { get; set; }

		public Message? ReplyTo { get; set; }

		public ICollection<Message>? Replies { get; set; }

		public string? Attachment { get; set; }

		public int? AttachmentTypeId { get; set; }

		public AttachmentType? AttachmentType { get; set; }
	}
}
