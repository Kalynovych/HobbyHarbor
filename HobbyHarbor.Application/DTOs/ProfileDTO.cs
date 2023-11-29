namespace HobbyHarbor.Application.DTOs
{
    public class ProfileDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Surname { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public int Age { get; set; }

        public string? Country { get; set; }

        public string? Sex { get; set; }

        public DateTime Birthdate { get; set; }

        public DateTime LastActivity { get; set; }

        public string? About { get; set; }

        public ICollection<InterestDTO> UserInterests { get; set; }

        public short PublicChatsAmount { get; set; }

        public short PrivateChatsAmount { get; set; }

        public ICollection<PostDTO>? Posts { get; set; }

        public ICollection<ImageDTO>? Images { get; set; }
    }
}
