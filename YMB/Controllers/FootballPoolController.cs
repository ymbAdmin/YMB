using System;
using System.Linq;
using System.Web.Mvc;
using YMB.Models;
using YMB.Factory;
using YMB.Extensions;
using System.Collections.Generic;

namespace YMB.Controllers
{

    [Authorize(Roles = "FootballPool", NotifyUrl = "~/FootballPool")]
    public class FootballPoolController : Controller
    {



        // GET: FootballPool
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyDashboard()
        {
            int simpleUserId = Convert.ToInt32(User.Identity.GetSimpleUserId());
            FootballPoolViewModel vw = FootballPoolFactory.GetUserAlerts(simpleUserId);
            return View(vw);
        }

        public ActionResult Leaderboard()
        {
            FootballPoolViewModel vw = FootballPoolFactory.GetLeaderboard();
            return View(vw);
        }


        [HttpPost]
        [AllowAnonymous]
        public Boolean RegisterUserForPool(string userId, int simpleUserId, string userName)
        {
            try
            {
                FootballPoolFactory.RegisterUserForPool(userId, simpleUserId, userName);
            }
            catch (Exception e)
            {
                LoggerFactory.LogError("RegisterUserForPool", string.Format("Message: {0} more details: {1}", e.Message, e.InnerException.Message), e.StackTrace, Convert.ToString(simpleUserId));
                return false;
            }
            return true;
        }

        [HttpGet]
        public ActionResult WeeklySchedule()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WeeklySchedule(int weekId, int simpleUserId)
        {
            // int simpleUserId = Convert.ToInt32(User.Identity.GetSimpleUserId());
            FootballPoolViewModel vw = FootballPoolFactory.BuildFootballPoolViewModel(weekId, simpleUserId);
            ViewBag.WeekId = weekId;
            return View(vw);
        }

        [HttpPost]
        public Boolean SubmitPicks(Dictionary<string, string> picks, int weekId)//<gameId + 1, team id picked >
        {
            int simpleUserId = Convert.ToInt32(User.Identity.GetSimpleUserId());
            try
            {
                LoggerFactory.LogInfo("Attempting to submit picks", "Week: " + weekId, "", User.Identity.GetSimpleUserId());
                FootballPoolFactory.SubmitPicks(picks, simpleUserId, weekId);
            }
            catch (Exception e)
            {
                LoggerFactory.LogError("SubmitPicks", string.Format("Message: {0} more details: {1}", e.Message, e.InnerException.Message), e.StackTrace, User.Identity.GetSimpleUserId());
                return false;
            }
            LoggerFactory.LogInfo("Successfully submitted picks", "Week: " + weekId, "", User.Identity.GetSimpleUserId());
            return true;
        }



        public ActionResult AccountProfile(string message)
        {
            if (!String.IsNullOrEmpty(message))
            {
                ViewBag.StatusMessage = message;
            }
            else
            {
                ViewBag.StatusMessage = "";
            }

            int simpleUserId = Convert.ToInt32(User.Identity.GetSimpleUserId());
            FootballPoolViewModel vw = FootballPoolFactory.BuildAccountProfileViewModel(simpleUserId);
            return View(vw);
        }

        public Boolean deleteAlert(int alertId)
        {
            Boolean result = false;
            try
            {
                FootballPoolFactory.DeleteAlert(alertId);
                result = true;
            }
            catch (Exception e)
            {
                LoggerFactory.LogError("DeleteAlert", string.Format("Message: {0}", e.Message), e.StackTrace, User.Identity.GetSimpleUserId());
            }
            return result;
        }

        [HttpGet]
        public ActionResult GameResults()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GameResults(int weekId)
        {
            ModelState.Clear();
            FootballPoolViewModel vw = FootballPoolFactory.BuildFootballPoolViewModel(weekId, 0);
            return View(vw);
        }

        [HttpGet]
        public ActionResult UserPicks()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserPicks(int weekId, int simpleUserId)
        {
            ModelState.Clear();
            FootballPoolViewModel vw = FootballPoolFactory.BuildFootballPoolViewModel(weekId, simpleUserId);
            return View(vw);
        }
    }
}