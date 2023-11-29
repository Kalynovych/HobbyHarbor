using HobbyHarbor.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HobbyHarbor.WebUI.ViewComponents
{
	public class MessagesListViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke(ICollection<MessageViewModel> model)
		{
			return View(model);
		}
	}
}
