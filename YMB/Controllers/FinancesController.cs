using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YMB.Models;
using YMB.Factory;
using YMB.Utility;

namespace YMB.Controllers
{
    [Authorize(Roles = "FinanceAdmin")]
    public class FinancesController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: MyFinances
        public async Task<ActionResult> Index()
        {
            List<Accounts> myAccounts = FinanceFactory.GetAccounts();
            var thisPaycheckDate = _db.Paycheck.Find(1).paycheckDate;
            // make next paycheck in 2 weeks
            var nextPaycheckDate = thisPaycheckDate.AddDays(14);
            
            //test now with thisPaycheckDate to update date or not
            if (CustomDateFunctions.GetDateTime() > thisPaycheckDate.AddDays(1))
            {
                FinanceFactory.UpdatePaycheckDate(nextPaycheckDate);
            }
            ViewBag.TotalCashAccounts = FinanceFactory.GetTotalValueOfAccounts(myAccounts, 1);
            ViewBag.TotalCreditAccounts = FinanceFactory.GetTotalValueOfAccounts(myAccounts, 2);
            ViewBag.NextPaycheck = (string.Format("{0}/{1}/{2}", thisPaycheckDate.Month, thisPaycheckDate.Day, thisPaycheckDate.Year));
            ViewBag.BillsListPayCheck = FinanceFactory.GetBillsDue(thisPaycheckDate, nextPaycheckDate);
            
            return View(myAccounts);
        }

        // GET: MyFinances/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Accounts accounts = await _db.Accounts.FindAsync(id);
            accounts.acctTrans = FinanceFactory.GetAccountTransactions(id);
            
            if (accounts == null)
            {
                return HttpNotFound();
            }
            return View(accounts);
        }

        [HttpPost]
        public ActionResult AddTransactions(int acctId, int tranType, string tranDesc, decimal tranAmount, int acctType, Boolean pending)
        {
            FinanceFactory.AddTransaction(acctId, tranType, tranDesc, tranAmount, acctType, pending);
            return RedirectToAction("Details", new { id = acctId });
        }

        [HttpPost]
        public ActionResult DeleteTransaction(int acctId, int tranId)
        {
            FinanceFactory.DeleteTransaction(acctId, tranId);
            return RedirectToAction("Details", new { id = acctId });
        }

        [HttpPost]
        public ActionResult PendingTransaction(int acctId, int tranId)
        {
            FinanceFactory.PendingTransaction(acctId, tranId);
            return RedirectToAction("Details", new { id = acctId });
        }
    }
}
