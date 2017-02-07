using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kippenbout.Models;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;

namespace Kippenbout.Controllers
{

    [Authorize(Roles = "Admin,Kok,Medewerker")]
    public class GerechtController : Controller
    {
       
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Gerecht
        public ActionResult Index()
        {


            return View(db.Gerechten.ToList());
        }

        public void ExportToCSV()
        {

            ApplicationDbContext db = new ApplicationDbContext();
            StringWriter sw = new StringWriter();
            sw.WriteLine("\"ID\",\"Naam\",\"Omschrijving\",\"Type gerecht\",\"Prijs\"");

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=ExportedGerechtenList.csv");
            Response.ContentType = "text/csv";

            var Gerechten = db.Gerechten.ToList();

            foreach (var Gerecht in Gerechten)
            {
                sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\"",

                    Gerecht.Id,
                    Gerecht.Naam,
                    Gerecht.Omschrijving,
                    Gerecht.Soort,
                    Gerecht.Prijs));

            }

            Response.Write(sw.ToString());
            Response.End();

        }

        public void ExportToExcel()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var grid = new GridView();

            grid.DataSource = from data in db.Gerechten.ToList()
                              select new
                              {
                                  ID = data.Id,
                                  Naam = data.Naam,
                                  Omschrijving = data.Omschrijving,
                                  Soort = data.Soort,
                                  Prijs = data.Prijs
                              };

            grid.DataBind();

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=ExportedGerechtenList.xls");
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter HtmlTextWriter = new HtmlTextWriter(sw);

            grid.RenderControl(HtmlTextWriter);

            Response.Write(sw.ToString());

            Response.End();


        }

        // GET: Gerecht/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gerecht gerecht = db.Gerechten.Find(id);
            if (gerecht == null)
            {
                return HttpNotFound();
            }
            return View(gerecht);
        }

        // GET: Gerecht/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gerecht/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Naam,Soort,Omschrijving,Prijs")] Gerecht gerecht)
        {
            if (ModelState.IsValid)
            {
                db.Gerechten.Add(gerecht);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gerecht);
        }

        // GET: Gerecht/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gerecht gerecht = db.Gerechten.Find(id);
            if (gerecht == null)
            {
                return HttpNotFound();
            }
            return View(gerecht);
        }

        // POST: Gerecht/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Naam,Soort,Omschrijving,Prijs")] Gerecht gerecht)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gerecht).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gerecht);
        }

        // GET: Gerecht/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gerecht gerecht = db.Gerechten.Find(id);
            if (gerecht == null)
            {
                return HttpNotFound();
            }
            return View(gerecht);
        }

        // POST: Gerecht/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gerecht gerecht = db.Gerechten.Find(id);
            db.Gerechten.Remove(gerecht);
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
