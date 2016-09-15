using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using YMB.Models;
using YMB.Factory;
using YMB.Extensions;
using System.Collections.Generic;
using YMB.Utility;

namespace YMB.Controllers
{

    [Authorize(Roles = "FootballPool", NotifyUrl = "~/FootballPool")]
    public class FootballPoolController : Controller
    {

        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: FootballPool
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyDashboard()
        {
            return View();
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

        [HttpGet]
        public ActionResult GameScores(int? weekID)
        {
            if (weekID > 0)
            {
                return RedirectToAction("GameScores", "FootballPool", new { weekId = weekID });
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult GameScores(int weekId)
        {
            ModelState.Clear();
            FootballPoolViewModel vw = FootballPoolFactory.BuildFootballPoolViewModel(weekId, 0);
            return View(vw);
        }

        [HttpPost]
        public ActionResult SubmitGameScores(FootballPoolViewModel thisVW)
        {
            try
            {
                FootballPoolFactory.SubmitGameScores(thisVW);
                FootballPoolFactory.UpdateTeamInfo();
            }
            catch (Exception e)
            {
                LoggerFactory.LogError("SubmitGameScores", string.Format("Message: {0} more details: {1}", e.Message, e.InnerException.Message), e.StackTrace, User.Identity.GetSimpleUserId());
            }

            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public ActionResult GenerateUserScores()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GenerateUserScores(int weekId)
        {
            try
            {
                LoggerFactory.LogInfo("GenerateUserScores", "Starting to generate user scores...", "Week: " + Convert.ToString(weekId), "Admin");
                FootballPoolFactory.GenerateUserScores(weekId);
            }
            catch (Exception e)
            {
                var me = e.Message;
                //LoggerFactory.LogError("GenerateUserScores", string.Format("Message: {0} more details: {1}", e.Message, Convert.ToString(e.InnerException.Message)), e.StackTrace, "Admin");
            }

            return View();
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

        [HttpGet]
        public ActionResult CheckUserPicks(int? weekID)
        {
            if (weekID > 0)
            {
                return RedirectToAction("CheckUserPicks", "FootballPool", new { weekId = weekID });
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult CheckUserPicks(int weekId)
        {
            ModelState.Clear();
            FootballPoolViewModel vw = FootballPoolFactory.CheckUserPicks(weekId);
            return View(vw);
        }

        [HttpGet]
        public ActionResult SendEmailReminder(int? weekID)
        {
            if (weekID > 0)
            {
                return RedirectToAction("SendEmailReminder", "FootballPool", new { weekId = weekID });
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public async Task<ActionResult> SendEmailReminder(int weekId)
        {
            ModelState.Clear();
            var nextGameTimeId = FootballPoolFactory.GetNextGameTimeId(weekId);
            var nextGameTime = FootballPoolFactory.GetGameTime(nextGameTimeId);
            
            List<ApplicationUser> userList = FootballPoolFactory.GenerateUserListThatHaveNotMadePicksThisWeek(weekId, nextGameTimeId);
            try
            {
                foreach (var user in userList)
                {
                    if (user.UserName == "asutton")
                    {
                        await UserManager.SendEmailAsync(user.Id, string.Format("Football Pick Reminder Week {0}", weekId), string.Format("You are recieving this reminder because you have not submitted a pick for the next game(s) on {0} {1} at {2} ", nextGameTime.ToString("dddd"), nextGameTime.ToString("m"), nextGameTime.ToString("t"))); 
                    }

                }

            }
            catch (Exception e)
            {
                LoggerFactory.LogError("ForgotPassword", string.Format("Message: {0} more details: {1}", e.Message, e.InnerException.Message), e.StackTrace, "");
            }

            return RedirectToAction("Index", "Admin");
        }
    }
}