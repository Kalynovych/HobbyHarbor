using HobbyHarbor.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HobbyHarbor.WebUI.ViewComponents
{
	public class CommentViewComponent : ViewComponent 
	{
		public IViewComponentResult Invoke(CommentViewModel model)
		{
			return View(model);
		}
	}
}
