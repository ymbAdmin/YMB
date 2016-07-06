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
    public class BeersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Beers
        public async Task<ActionResult> Index()
        {
            Beers beerModel = new Beers();
            //beerModel = 
            return View(BeersFactory.GetBeerList());
        }

        // GET: Beers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beers beers = await db.Beers.FindAsync(id);
            if (beers == null)
            {
                return HttpNotFound();
            }
            return View(beers);
        }

        // GET: Beers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Beers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "BeerAdmin")]
        public async Task<ActionResult> Create(Beers beers)
        {
            if (ModelState.IsValid)
            {
                db.Beers.Add(beers);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(beers);
        }

        // GET: Beers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beers beers = await db.Beers.FindAsync(id);
            if (beers == null)
            {
                return HttpNotFound();
            }
            return View(beers);
        }

        // POST: Beers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "beerId,beerName,beerStyle,beerABV,beerCalories,beerIBU,beerDesc")] Beers beers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(beers).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(beers);
        }

        // GET: Beers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Beers beers = await db.Beers.FindAsync(id);
            if (beers == null)
            {
                return HttpNotFound();
            }
            return View(beers);
        }

        // POST: Beers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Beers beers = await db.Beers.FindAsync(id);
            db.Beers.Remove(beers);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
