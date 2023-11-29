using HobbyHarbor.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HobbyHarbor.WebUI.ViewComponents
{
	public class MessageViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke(MessageViewModel model)
		{
			return View(model);
		}
	}
}
