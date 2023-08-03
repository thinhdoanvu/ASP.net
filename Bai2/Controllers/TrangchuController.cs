using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai2.Controllers
{
    public class TrangchuController : Controller
    {
        // GET: Trangchu
        public ActionResult Index()
        {
            ViewBag.WelcomeString = "Chào mừng đến với ViewBag";
            return View();
        }
    }
}