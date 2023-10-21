namespace HobbyHarbor.WebUI.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }

        public int CreatorId { get; set; }

        public ImageModel ProfileImage { get; set; }

        public string Name { get; set; }

        public string? Surname { get; set; }

        public string Username { get; set; }

        public ICollection<InterestModel> PostInterests { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public ICollection<CommentViewModel>? Comments { get; set; }

        public string PostTitle { get; set; }

        public string PostContent { get; set; }

        public string? Attachment { get; set; }

        public string? AttachmentType { get; set; }

        public DateTime PublicationTime { get; set; }
    }
}
