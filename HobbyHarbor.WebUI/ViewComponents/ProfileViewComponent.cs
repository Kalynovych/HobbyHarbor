using HobbyHarbor.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HobbyHarbor.WebUI.ViewComponents
{
	public class ProfileViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke(ProfileViewModel model)
		{
			return View(model);
		}
	}
}
