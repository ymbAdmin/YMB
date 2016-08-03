using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YMB.Factory;
using YMB.Models;

namespace YMB.Controllers
{
    [Authorize(Roles = "SiteAdmin")]
    public class AdminController : Controller
    {
        
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
        public Boolean SendRequest(string reqType, string name, string addr, string city, string state, string zip, string email, string comments)
        {
            try
            {
                RequestFactory.SendRequest(reqType, name, email, addr, state, city, zip, comments);
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