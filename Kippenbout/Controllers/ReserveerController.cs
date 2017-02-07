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
    public class ReserveerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reserveer
        public ActionResult Index()
        {
            return View(db.ReserveerModels.ToList());
        }

        // GET: Reserveer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReserveerModel reserveerModel = db.ReserveerModels.Find(id);
            if (reserveerModel == null)
            {
                return HttpNotFound();
            }
            return View(reserveerModel);
        }

        // GET: Reserveer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reserveer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RevereringID,Menu,Personen,Tijd")] ReserveerModel reserveerModel)
        {
            if (ModelState.IsValid)
            {
                db.ReserveerModels.Add(reserveerModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reserveerModel);
        }

        // GET: Reserveer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReserveerModel reserveerModel = db.ReserveerModels.Find(id);
            if (reserveerModel == null)
            {
                return HttpNotFound();
            }
            return View(reserveerModel);
        }

        // POST: Reserveer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RevereringID,Menu,Personen,Tijd")] ReserveerModel reserveerModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reserveerModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reserveerModel);
        }

        // GET: Reserveer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReserveerModel reserveerModel = db.ReserveerModels.Find(id);
            if (reserveerModel == null)
            {
                return HttpNotFound();
            }
            return View(reserveerModel);
        }

        // POST: Reserveer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReserveerModel reserveerModel = db.ReserveerModels.Find(id);
            db.ReserveerModels.Remove(reserveerModel);
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
