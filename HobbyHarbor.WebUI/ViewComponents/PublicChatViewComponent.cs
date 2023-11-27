using HobbyHarbor.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HobbyHarbor.WebUI.ViewComponents
{
	public class PublicChatViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke(PublicChatViewModel model)
		{
			return View(model);
		}
	}
}
