
using System.Web.Mvc;
using HotelRestApi.Repositories;

namespace HotelRestApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
