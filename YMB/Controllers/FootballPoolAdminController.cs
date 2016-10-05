using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using YMB.Models;
using YMB.Factory;
using YMB.Extensions;
using System.Collections.Generic;


namespace YMB.Controllers
{
    [Authorize(Roles = "FootballPoolAdmin", NotifyUrl = "~/FootballPool")]
    public class FootballPoolAdminController : Controller
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

        [HttpGet]
        public ActionResult GameScores()
        {
                return View();
            
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

            return RedirectToAction("Index", "Admin");
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

                    await UserManager.SendEmailAsync(user.Id, string.Format("Football Pick Reminder Week {0}", weekId), string.Format("You are recieving this reminder because you have not submitted a pick for the next game(s) on {0} {1} at {2} ", nextGameTime.ToString("dddd"), nextGameTime.ToString("m"), nextGameTime.ToString("t")));


                }

            }
            catch (Exception e)
            {
                LoggerFactory.LogError("ForgotPassword", string.Format("Message: {0} more details: {1}", e.Message, e.InnerException.Message), e.StackTrace, "");
            }

            return RedirectToAction("Index", "Admin");
        }

        public ActionResult CheckEntryFees()
        {
            FootballPoolViewModel vw = FootballPoolFactory.CheckEntryFees();
            return View(vw);
        }

        [HttpPost]
        public ActionResult UpdateEntryFees(int simpleUserId)
        {
            FootballPoolFactory.UpdateEntryFeeFlag(simpleUserId);
            return RedirectToAction("CheckEntryFees", "FootballPool");
        }

        [HttpGet]
        public ActionResult SendEmail()
        {
            List<ApplicationUser> userList = FootballPoolFactory.GetAllUsers();
            return View(userList);
        }

        [HttpPost]
        public async Task<ActionResult> SendEmail(List<int> simpleUserIds, string emailSubject, string emailMessage)
        {
            try
            {
                List<ApplicationUser> userList = FootballPoolFactory.GetUserListFromIds(simpleUserIds);
                foreach (var user in userList)
                {
                    await UserManager.SendEmailAsync(user.Id, Convert.ToString(emailSubject), Convert.ToString(emailMessage));
                }
            }
            catch (Exception e)
            {
                LoggerFactory.LogError("SendEmail", string.Format("Message: {0}", Convert.ToString(e.Message)), Convert.ToString(e.StackTrace), "Admin");
            }
            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public ActionResult AddAlert()
        {
            List<ApplicationUser> userList = FootballPoolFactory.GetAllUsers();
            return View(userList);
        }

        [HttpPost]
        public ActionResult AddAlert(List<int> simpleUserIds, string alertTitle, string alertText, Boolean userCanDelete)
        {
            try
            {
                List<ApplicationUser> userList = FootballPoolFactory.GetUserListFromIds(simpleUserIds);
                foreach (var user in userList)
                {
                    FootballPoolFactory.AddAlert(user.simpleUserId, alertTitle, alertText, userCanDelete);
                }
            }
            catch (Exception e)
            {
                LoggerFactory.LogError("AddAlert", string.Format("Message: {0}", Convert.ToString(e.Message)), Convert.ToString(e.StackTrace), "Admin");
            }
            return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        public void UpdateAlertReadFlag(Boolean read, int alertId)
        {
            FootballPoolFactory.UpdateAlertReadFlag(alertId);
        }
    }
}