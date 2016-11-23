using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YMB.Controllers
{
    public class CompetitionsController : Controller
    {
        // GET: Competitions
        public ActionResult Index()
        {
            return View();
        }
    }
}