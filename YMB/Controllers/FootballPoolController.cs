using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YMB.Factory;
using YMB.Models;

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
        public ActionResult MyDashboard()
        {
            WeeklySchedule(1);
            return View();
        }

        [HttpPost]
        public void RegisterUserForPool(string userId, int simpleUserId, string userName)
        {
            try
            {
                FootballPoolFactory.RegisterUserForPool(userId, simpleUserId, userName);
            }
            catch (Exception e) { }
        }

        public ActionResult WeeklySchedule(int weekId)
        {
            FootballPoolViewModel vw = FootballPoolFactory.GetWeeklyFootballBallSchedule(weekId);
            return View(vw);
        }
    }
}