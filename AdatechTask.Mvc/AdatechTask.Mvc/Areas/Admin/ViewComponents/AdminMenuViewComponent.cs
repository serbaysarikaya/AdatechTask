using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace AdatechTask.Mvc.Areas.Admin.ViewComponents
{
	public class AdminMenuViewComponent : ViewComponent
	{
		public AdminMenuViewComponent()
		{

		}
		public ViewViewComponentResult Invoke()
		{
			return View();
		}
	}
}
