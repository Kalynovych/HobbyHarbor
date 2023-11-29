namespace HobbyHarbor.Core.Entities
{
	public class PostsReaction
	{
		public int UserId { get; set; }

		public User User { get; set; }

		public int PostId { get; set; }

		public Post Post { get; set; }

		public bool IsLiked { get; set; }
	}
}
