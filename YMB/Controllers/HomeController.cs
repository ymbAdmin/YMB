using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YMB.Models;
using YMB.Factory;

namespace YMB.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
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
        [HttpPost]
        public ActionResult SendRequest(int reqId, string name, string addr, string city, string state, string zip, string email, string comments)
        {
            
            Requests newRequest = new Requests(reqId,name,email,addr,state,city,zip,comments);
            _db.Requests.Add(newRequest);
            try
            {
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                var error_text = e.InnerException.InnerException.Message;
            }
            
            return View("Index");
        }
    }
}