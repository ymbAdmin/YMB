using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YMB.Factory;

namespace YMB.Controllers
{

    public class FootballPoolController : Controller
    {
        // GET: FootballPool
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "FootballPool", NotifyUrl = "~/FootballPool")]
        public ActionResult MyDashboard(int simpleUserId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUserForPool(string userId, int simpleUserId, string userName)
        {
            FootballPoolFactory.RegisterUserForPool(userId, simpleUserId, userName);
            return View("MyDashboard", new { @simpleUserId = simpleUserId });
        }
    }
}