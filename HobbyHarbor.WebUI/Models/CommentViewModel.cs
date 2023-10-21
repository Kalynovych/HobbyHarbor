namespace HobbyHarbor.WebUI.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }

		public ImageModel ProfileImage { get; set; }

		public string Name { get; set; }

		public string? Surname { get; set; }

        public string Username { get; set; }

		public string Text { get; set; }

        public int PostId { get; set; }

        public int? ReplyCommentId { get; set; }

        public string? ReplyCommentUsername { get; set; }

        public DateTime Time { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }
    }
}
