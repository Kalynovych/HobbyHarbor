namespace HobbyHarbor.Core.Entities
{
    public class InterestCategory
    {
        public int Id {  get; set; }

        public string CategoryName { get; set; }

        public ICollection<Interest> Interests { get; set; }
    }
}
