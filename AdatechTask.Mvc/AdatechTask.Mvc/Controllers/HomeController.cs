using Microsoft.AspNetCore.Mvc;

namespace AdatechTask.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}