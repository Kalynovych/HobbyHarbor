using HobbyHarbor.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HobbyHarbor.WebUI.ViewComponents
{
	public class PostViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke(PostViewModel model)
		{
			return View(model);
		}
	}
}
