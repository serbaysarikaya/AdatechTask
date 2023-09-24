using AdatechTask.Mvc.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace AdatechTask.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {

        private LanguageService _localization;
        public HomeController(LanguageService localization)
        {

            _localization = localization;
        }
        public IActionResult Index()
        {
            ViewBag.Admin = _localization.Getkey("Admin").Value;
            ViewBag.Admin_panel = _localization.Getkey("Admin_Panel").Value;
            ViewBag.Menu = _localization.Getkey("Menu").Value;
            ViewBag.Book = _localization.Getkey("Book").Value;
            ViewBag.Logged = _localization.Getkey("Logged").Value;
            ViewBag.Contents = _localization.Getkey("Contents").Value;
            ViewBag.ID = _localization.Getkey("").Value;
            ViewBag.BookName = _localization.Getkey("BookName").Value;
            ViewBag.Writer = _localization.Getkey("Writer").Value;
            ViewBag.PublicationDate = _localization.Getkey("PublicationDate").Value;
            ViewBag.ISBN = _localization.Getkey("ISBN").Value;
            ViewBag.BookCategory = _localization.Getkey("BookCategory").Value;
            ViewBag.NumberPages = _localization.Getkey("NumberPages").Value;
            ViewBag.Publisher = _localization.Getkey("Publisher").Value;
            ViewBag.IsActive = _localization.Getkey("IsActive").Value;
            ViewBag.IsDeleted = _localization.Getkey("IsDeleted").Value;
            ViewBag.RegistrationDate = _localization.Getkey("RegistrationDate").Value;
            ViewBag.RegisteredUser = _localization.Getkey("RegisteredUser").Value;
            ViewBag.EditedDate = _localization.Getkey("EditedDate").Value;
            ViewBag.EditedUser = _localization.Getkey("EditedUser").Value;
            ViewBag.Admin2 = _localization.Getkey("Admin2").Value;
            ViewBag.Catogories = _localization.Getkey("Catogories").Value;
            ViewBag.Catogories = _localization.Getkey("Localization").Value;
            var currentCulture = Thread.CurrentThread.CurrentCulture.Name;
            return View();
        }
        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1)
                });
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
