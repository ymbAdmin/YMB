using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using YMB.Factory;
using YMB.Models;

namespace YMB.Controllers
{
    [Authorize(Roles = "SiteAdmin")]
    public class AdminController : Controller
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
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Requests()
        {
            return View(RequestFactory.GetRequests());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<Boolean> SendRequest(string reqType, string name, string addr, string city, string state, string zip, string email, string comments)
        {
            try
            {
                RequestFactory.SendRequest(reqType, name, email, addr, state, city, zip, comments);
                await UserManager.SendEmailAsync("9bfa7dfb-36f3-4112-9bd7-4784cb0f07ba", "YMB Request", string.Format("Request from {0}. Request type: {1} Return Email: {2} Address Info: {3} Message: {4}", name, reqType, email, string.Format("{0} {1},{2} {3}", addr, city, state, zip), comments));
            }
            catch (Exception e)
            {
                var error_text = e.InnerException.InnerException.Message;
                return false;
            }

            return true;
        }

        [HttpPost]
        public Boolean ProcessRequest(int reqId)
        {
            try
            {
                RequestFactory.ProcessRequest(reqId);
            }
            catch (Exception e)
            {
                var error_text = e.InnerException.InnerException.Message;
                return false;
            }

            return true;
        }

        [HttpPost]
        public Boolean UnprocessRequest(int reqId)
        {
            try
            {
                RequestFactory.UnprocessRequest(reqId);
            }
            catch (Exception e)
            {
                var error_text = e.InnerException.InnerException.Message;
                return false;
            }

            return true;
        }

        public Boolean DeleteRequest(int reqId)
        {
            try
            {
                RequestFactory.DeleteRequest(reqId);
            }
            catch (Exception e)
            {
                var error_text = e.InnerException.InnerException.Message;
                return false;
            }

            return true;
        }
    }
}