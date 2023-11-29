namespace HobbyHarbor.Core.Entities
{
	public class CommentsReaction
	{
		public int UserId { get; set; }

		public User User { get; set; }

		public int CommentId { get; set; }

		public Comment Comment { get; set; }

		public bool IsLiked { get; set; }
	}
}
