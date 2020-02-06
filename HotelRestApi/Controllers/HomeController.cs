using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelRestApi.DAL;

namespace HotelRestApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            FakeData.SeedData();
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
