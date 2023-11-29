namespace HobbyHarbor.Core.Entities
{
    public class Profile
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public string Name { get; set; }

        public string? Surname { get; set; }

        public int Age { get; set; }

        public string? Country { get; set; }

        public string? Sex { get; set; }

        public DateTime Birthdate { get; set; }

        public string? About { get; set; }

        public ICollection<ProfileImage>? Images { get; set; }
    }
}
