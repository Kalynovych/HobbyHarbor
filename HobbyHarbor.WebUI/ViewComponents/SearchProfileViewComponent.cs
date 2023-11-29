using HobbyHarbor.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HobbyHarbor.WebUI.ViewComponents
{
	public class SearchProfileViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke(ProfileViewModel model)
		{
			return View(model);
		}
	}
}
