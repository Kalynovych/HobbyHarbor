﻿namespace HobbyHarbor.Application.DTOs
{
    public class MessageDTO
    {
        public int Id { get; set; }

        public int MessageAuthorId { get; set; }

        public string MessageText { get; set; }

		public string AuthorUsername { get; set; }

		public string AuthorName { get; set; }

        public string AuthorProfileImage { get; set; }

        public DateTime Time { get; set; }

        public int? ReplyMessageId { get; set; }

		public string ReplyMessageText { get; set; }

		public string? Attachment { get; set; }

        public int? AttachmentType { get; set; }
    }
}
