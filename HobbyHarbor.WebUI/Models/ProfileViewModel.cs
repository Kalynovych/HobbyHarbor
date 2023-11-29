namespace HobbyHarbor.WebUI.Models
{
    public class ProfileViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Surname { get; set; }

        public string Username { get; set; }

        public int Age { get; set; }

        public string? Country { get; set; }

        public string? Sex { get; set; }

        public DateTime Birthdate { get; set; }

        public string OnlineStatus { get; set; }

        public string? About { get; set; }

        public ICollection<InterestModel> UserInterests { get; set; }

        public short PublicChatsAmount { get; set; }

        public short PrivateChatsAmount { get; set; }

        public ICollection<PostViewModel>? Posts { get; set; }

        public ImageModel ProfileImage { get; set; }

        public ImageModel BannerImage { get; set; }

        public ICollection<ImageModel>? GalleryImages { get; set; }
    }
}
