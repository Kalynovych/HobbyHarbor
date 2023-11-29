namespace HobbyHarbor.Core.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }

        public User Author { get; set; }

        public string Text { get; set; }

        public int PostId { get; set; }

        public Post Post { get; set; }

        public int? ReplyCommentId { get; set; }

        public Comment? ReplyTo {  get; set; }

        public DateTime Time {  get; set; }

        public ICollection<CommentsReaction>? Reactions { get; set; }
	}
}
