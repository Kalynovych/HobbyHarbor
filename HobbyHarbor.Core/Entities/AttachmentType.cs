namespace HobbyHarbor.Core.Entities
{
    public class AttachmentType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; }

        public ICollection<Message> Messages { get; set; }
    }
}
