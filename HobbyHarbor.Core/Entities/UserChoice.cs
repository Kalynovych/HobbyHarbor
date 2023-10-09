namespace HobbyHarbor.Core.Entities
{
    public class UserChoice
    {
        public int UserId { get; set; }

        public int TargetId { get; set; }
        
        public User User { get; set; }

        public User Target { get; set; }

        public bool IsLiked { get; set; }

        public DateTime Time {  get; set; }
    }
}
