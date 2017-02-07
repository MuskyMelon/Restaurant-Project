using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kippenbout.Models;

namespace Kippenbout.Controllers
{
    public class ReserveringsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reserverings
        public ActionResult Index()
        {
            return View(db.ReserveerModels.ToList());
        }

        // GET: Reserverings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservering reservering = db.ReserveerModels.Find(id);
            if (reservering == null)
            {
                return HttpNotFound();
            }
            return View(reservering);
        }

        // GET: Reserverings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reserverings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RevereringID,Menu,Personen,Tijd")] Reservering reservering)
        {
            if (ModelState.IsValid)
            {
                db.ReserveerModels.Add(reservering);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reservering);
        }

        // GET: Reserverings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservering reservering = db.ReserveerModels.Find(id);
            if (reservering == null)
            {
                return HttpNotFound();
            }
            return View(reservering);
        }

        // POST: Reserverings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RevereringID,Menu,Personen,Tijd")] Reservering reservering)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservering).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reservering);
        }

        // GET: Reserverings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservering reservering = db.ReserveerModels.Find(id);
            if (reservering == null)
            {
                return HttpNotFound();
            }
            return View(reservering);
        }

        // POST: Reserverings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservering reservering = db.ReserveerModels.Find(id);
            db.ReserveerModels.Remove(reservering);
            db.SaveChanges();
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
