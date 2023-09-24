using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace AdatechTask.Mvc.Areas.Admin.ViewComponents
{
	public class UserMenuViewComponent : ViewComponent
	{
		public UserMenuViewComponent()
		{

		}

		public ViewViewComponentResult Invoke()
		{

			return View();

		}
	}
}
