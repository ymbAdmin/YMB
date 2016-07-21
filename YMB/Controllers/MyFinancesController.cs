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

namespace YMB.Controllers
{
    [Authorize(Roles = "FinanceAdmin")]
    public class MyFinancesController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        // GET: MyFinances
        public async Task<ActionResult> Index()
        {

            var date = _db.Paycheck.Find(1).paycheckDate;
            if (DateTime.Now > date){
                // make next paycheck in 2 weeks at 7am
                date = date.AddDays(14);
                date = date.AddHours(7);
                AccountsFactory.UpdatePaycheckDate(date);
            }
            ViewBag.NextPaycheck = (string.Format("{0}/{1}/{2}", date.Month, date.Day, date.Year));
            return View(await _db.Accounts.OrderBy(a => a.acctType).ThenBy(a => a.acctBalance).ToListAsync());
        }

        // GET: MyFinances/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Accounts accounts = await _db.Accounts.FindAsync(id);
            accounts.acctTrans = AccountsFactory.GetAccountTransactions(id);
            if (accounts == null)
            {
                return HttpNotFound();
            }
            return View(accounts);
        }

        // GET: MyFinances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MyFinances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "acctId,acctName,acctType")] Accounts accounts)
        {
            if (ModelState.IsValid)
            {
                _db.Accounts.Add(accounts);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(accounts);
        }

        // GET: MyFinances/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accounts accounts = await _db.Accounts.FindAsync(id);
            if (accounts == null)
            {
                return HttpNotFound();
            }
            return View(accounts);
        }

        // POST: MyFinances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "acctId,acctName,acctType")] Accounts accounts)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(accounts).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(accounts);
        }

        // GET: MyFinances/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accounts accounts = await _db.Accounts.FindAsync(id);
            if (accounts == null)
            {
                return HttpNotFound();
            }
            return View(accounts);
        }

        // POST: MyFinances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Accounts accounts = await _db.Accounts.FindAsync(id);
            _db.Accounts.Remove(accounts);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
        [HttpPost]
        public ActionResult AddTransactions(int acctId, int tranType, string tranDesc, decimal tranAmount, int acctType)
        {
            AccountsFactory.AddTransaction(acctId, tranType, tranDesc, tranAmount, acctType);
            return RedirectToAction("Details", new { id = acctId });
        }

        [HttpPost]
        public ActionResult DeleteTransaction(int acctId, int tranId)
        {
            AccountsFactory.DeleteTransaction(acctId, tranId);
            return RedirectToAction("Details", new { id = acctId });
        }
    }
}
