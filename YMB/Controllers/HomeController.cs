using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YMB.Models;
using YMB.Factory;
using System.Threading.Tasks;

namespace YMB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact YMB!";

            return View();
        }

        public ActionResult NewHome()
        {
            return View();
        }
    }
}