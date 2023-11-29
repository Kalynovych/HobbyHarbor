namespace HobbyHarbor.Application.DTOs
{
    public class PostDTO
    {
        public int Id { get; set; }

        public int CreatorId { get; set; }

        public ImageDTO ProfileImage { get; set; }

        public string Name { get; set; }

        public string? Surname { get; set; }

        public string Username { get; set; }

        public ICollection<InterestDTO> PostInterests { get; set; }

        public ICollection<CommentDTO>? Comments { get; set; }

        public string PostTitle { get; set; }

        public string PostContent { get; set; }

        public string? Attachment { get; set; }

        public string? AttachmentType { get; set; }

        public DateTime PublicationTime { get; set; }

		public bool? UserReaction { get; set; }

		public int Likes { get; set; }

        public int Dislikes { get; set; }
    }
}
