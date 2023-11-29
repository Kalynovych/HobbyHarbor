namespace HobbyHarbor.Core.Entities
{
    public class ProfileImage
    {
        public int Id { get; set; }

        public int ProfileId { get; set; }

        public Profile Profile { get; set; }
        
        public string Image { get; set; }
    }
}
