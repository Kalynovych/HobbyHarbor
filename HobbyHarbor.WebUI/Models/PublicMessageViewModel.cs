namespace HobbyHarbor.WebUI.Models
{
	public class PublicMessageViewModel : MessageViewModel
	{
		public int PublicChatId { get; set; }

		public ICollection<string> Participants { get; set; }
	}
}
