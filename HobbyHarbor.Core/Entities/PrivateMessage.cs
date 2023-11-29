namespace HobbyHarbor.Core.Entities
{
    public class PrivateMessage : Message
    {
        public int CreatorId { get; set; }

        public int CompanionId { get; set; }

        public PrivateChat PrivateChat { get; set; }
    }
}
