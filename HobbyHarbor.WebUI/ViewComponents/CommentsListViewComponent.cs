using HobbyHarbor.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HobbyHarbor.WebUI.ViewComponents
{
	public class CommentsListViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke(IEnumerable<CommentViewModel> model)
		{
			return View(model);
		}
	}
}
