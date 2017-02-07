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
   [Authorize]
    public class MenusController : Controller
    {
        
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MenusList
        public ActionResult Index()
        {
            return View(db.Menus.Include("Voorgerecht").Include("Hoofdgerecht").Include("Nagerecht").ToList());
        }

        // GET: MenusList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // GET: MenusList/Create
        [Authorize(Roles = "Admin,Kok,Medewerker")]
        public ActionResult Create()
        {
            MenuViewModel GerechtFilter = new MenuViewModel();

            GerechtFilter.Nagerechten =
            from c in db.Gerechten
            where c.Soort == "Nagerecht"
            select new SelectListItem
            {
                Text = c.Naam,
                Value = c.Id.ToString()
            };

            GerechtFilter.Hoofdgerechten =
            from c in db.Gerechten
            where c.Soort == "Hoofdgerecht"
            select new SelectListItem
            {
                Text = c.Naam,
                Value = c.Id.ToString()
            };


            GerechtFilter.Voorgerechten =
            from c in db.Gerechten
            where c.Soort == "Voorgerecht"
            select new SelectListItem
            {
                Text = c.Naam,
                Value = c.Id.ToString()
            };



            return View(GerechtFilter);
        }

        // POST: MenusList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Id,Naam,VoorgerechtId,HoofdgerechtId,NagerechtId,Prijs")] MenuViewModel menuVm)
        {
            if (ModelState.IsValid)
            {
                Menu m = new Menu();
                m.Voorgerecht = (from g in db.Gerechten where g.Id == menuVm.VoorgerechtId select g).FirstOrDefault();
                m.Hoofdgerecht = (from g in db.Gerechten where g.Id == menuVm.HoofdgerechtId select g).FirstOrDefault();
                m.Nagerecht = (from g in db.Gerechten where g.Id == menuVm.NagerechtId select g).FirstOrDefault();
                m.Naam = menuVm.Naam;
                m.Prijs = m.Voorgerecht.Prijs + m.Hoofdgerecht.Prijs + m.Nagerecht.Prijs;
                db.Menus.Add(m);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(menuVm);
        }

        // GET: MenusList/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            MenuViewModel menuVm = new MenuViewModel();

            menuVm.Nagerechten =
            from c in db.Gerechten
            where c.Soort == "Nagerecht"
            select new SelectListItem
            {
                Text = c.Naam,
                Value = c.Id.ToString()
            };

            menuVm.Hoofdgerechten =
            from c in db.Gerechten
            where c.Soort == "Hoofdgerecht"
            select new SelectListItem
            {
                Text = c.Naam,
                Value = c.Id.ToString()
            };


            menuVm.Voorgerechten =
            from c in db.Gerechten
            where c.Soort == "Voorgerecht"
            select new SelectListItem
            {
                Text = c.Naam,
                Value = c.Id.ToString()
            };


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            menuVm.VoorgerechtId = menu.Voorgerecht.Id;
            menuVm.HoofdgerechtId = menu.Hoofdgerecht.Id;
            menuVm.NagerechtId = menu.Nagerecht.Id;
            menuVm.Naam = menu.Naam;
            menuVm.Prijs = menu.Prijs;
            menuVm.Id = menu.Id;
            return View(menuVm);
        }

        // POST: MenusList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,Naam,VoorgerechtId,HoofdgerechtId,NagerechtId,Prijs")] MenuViewModel menuVm)
        {
            Menu m = (from menu in db.Menus where menu.Id == menuVm.Id select menu).First();
            //Menu m = new Menu();
            //m.Id = menuVm.Id;
            m.Naam = menuVm.Naam;
            m.Prijs = menuVm.Prijs;
            if (ModelState.IsValid)
            {
                m.Voorgerecht = (from g in db.Gerechten where g.Id == menuVm.VoorgerechtId select g).FirstOrDefault();
                m.Hoofdgerecht = (from g in db.Gerechten where g.Id == menuVm.HoofdgerechtId select g).FirstOrDefault();
                m.Nagerecht = (from g in db.Gerechten where g.Id == menuVm.NagerechtId select g).FirstOrDefault();
               // db.Entry(m).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menuVm);
        }

        // GET: MenusList/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return HttpNotFound();
            }
            return View(menu);
        }

        // POST: MenusList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Menu menu = db.Menus.Find(id);
            db.Menus.Remove(menu);
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
