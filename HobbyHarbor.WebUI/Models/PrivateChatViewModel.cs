namespace HobbyHarbor.WebUI.Models
{
	public class PrivateChatViewModel
	{
		public string CompanionName { get; set; }

		public string CompanionProfileImage { get; set; }

		public DateTime LastMessageTime { get; set; }

		public string LastMessage { get; set; }

		public string LastMessageAuthor { get; set; }
	}
}
