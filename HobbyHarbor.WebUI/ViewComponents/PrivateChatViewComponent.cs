using HobbyHarbor.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HobbyHarbor.WebUI.ViewComponents
{
	public class PrivateChatViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke(PrivateChatViewModel model)
		{
			return View(model);
		}
	}
}
