namespace HobbyHarbor.Core.Entities
{
    public class PublicChatInterest
    {
        public int PublicChatId { get; set; }

        public int InterestId { get; set; }
        
        public PublicChat PublicChat { get; set; }

        public Interest Interest { get; set; }
    }
}
