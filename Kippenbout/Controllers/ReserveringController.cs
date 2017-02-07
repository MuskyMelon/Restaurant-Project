using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kippenbout.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Kippenbout.Controllers
{
    [Authorize]
    public class ReserveringController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reservering
        public ActionResult Index(string sortOrder,string searchString)
        {


            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var currentUser = manager.FindById(User.Identity.GetUserId());


            //Sort Date
            ViewBag.PrijsSortParm = sortOrder == "prijs" ? "prijs_desc" : "prijs";
            ViewBag.TafelSortParm = sortOrder == "tafel" ? "tafel_desc" : "tafel";
            ViewBag.TelSortParm = sortOrder == "tel" ? "tel_desc" : "tel";
            ViewBag.PersonSortParm = sortOrder == "person" ? "person_desc" : "person";
            ViewBag.NameSortParm = sortOrder == "name" ? "name_desc" : "name";
            ViewBag.DateSortParm = sortOrder == "date" ? "date_desc" : "Date";

            var res = from r in db.Reserveringen
                      where r.contact_Id == currentUser.Id && r.BeginDatum_tijd > DateTime.Now
                      select r;


            switch (sortOrder)
            {
                case "prijs":
                    res = res.OrderBy(s => s.Totaal_Prijs);
                    break;
                case "prijs_desc":
                    res = res.OrderByDescending(s => s.Totaal_Prijs);
                    break;
                case "tafel":
                    res = res.OrderBy(s => s.Tafel_Nummer);
                    break;
                case "tafel_desc":
                    res = res.OrderByDescending(s => s.Tafel_Nummer);
                    break;
                case "tel":
                    res = res.OrderBy(s => s.Contact_Telefoonnummer);
                    break;
                case "tel_desc":
                    res = res.OrderByDescending(s => s.Contact_Telefoonnummer);
                    break;
                case "person":
                    res = res.OrderBy(s => s.Personen);
                    break;
                case "person_desc":
                    res = res.OrderByDescending(s => s.Personen);
                    break;
                case "name":
                    res = res.OrderBy(s => s.Contact_Naam);
                    break;
                case "name_desc":
                    res = res.OrderByDescending(s => s.Contact_Naam);
                    break;
                case "date":
                    res = res.OrderBy(s => s.BeginDatum_tijd);
                    break;
                case "date_desc":
                    res = res.OrderByDescending(s => s.BeginDatum_tijd);
                    break;

            }

            
            return View(res.ToList());

          
        }

        [Authorize(Roles = "Admin,Kok,Medewerker")]
        public ActionResult AdminIndex()
        {
            return View(db.Reserveringen.ToList());
        }

        // GET: reservering checklist
        //[Authorize(Roles = "Medewerker")]
        //public ActionResult Aanwezigheid()
        //{
        //    var Aanwezig = from r in db.Reserveringen
        //                   where r.Datum >= DateTime.Now
        //                   && r.Aanwezig == false
        //                   select r;

        //    return View(Aanwezig.ToList());

        //}

        [Authorize(Roles = "Medewerker")]
        // GET: Reservering/AanwezigheidDetail/5
        public ActionResult AanwezigheidDetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservering reservering = db.Reserveringen.Find(id);
            if (reservering == null)
            {
                return HttpNotFound();
            }
            return View(reservering);
        }



        // GET: Reservering/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservering reservering = db.Reserveringen.Find(id);
            if (reservering == null)
            {
                return HttpNotFound();
            }

            return View(reservering);
        }

        // GET: Reservering/Create
        public ActionResult Create()
        {


            ReserveringViewModel Menusfilter = new ReserveringViewModel();

            

          
            Menusfilter.Personen = 0;
            Menusfilter.Tijd = DateTime.Now.TimeOfDay;

            //Menusfilter.Reservering =
            //(from d in db.Reserveringen
            //where d.Datum_tijd >= DateTime.Now
            //select d).ToList();



            //Menusfilter.Menus =
            //from c in db.Menus
            //select new SelectListItem
            //{
            //    Text = c.Naam + " " + c.Prijs,
            //    Value = c.Id.ToString()
            //};
        
            


            return View(Menusfilter);
        }

        // POST: Reservering/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReserveringViewModel reserveringVm)
        {
            TimeSpan extra = TimeSpan.FromHours(2);
            var Date = reserveringVm.Datum;
            var Time = reserveringVm.Tijd;
            var EndTIme = reserveringVm.Tijd.Add(extra);

            reserveringVm.Reservering =
          (from d in db.Reserveringen
           where d.Datum == Date && d.BeginTijd >= Time && d.BeginTijd < EndTIme || d.Datum == Date && d.EindTijd >= Time && d.EindTijd <= EndTIme
           select d).ToList();

            reserveringVm.Menus =
         from c in db.Menus
         select new SelectListItem
         {
             Text = c.Naam + " " + c.Prijs,
             Value = c.Id.ToString()
         };

            if (Request.Form["submit"] == "Pas datum en tijd aan")
            {
                reserveringVm.Personen = 0;
            }

                
            if (Request.Form["submit"] == "Create")
            {

                var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                var currentUser = manager.FindById(User.Identity.GetUserId());
                Reservering r = new Reservering();
                Tafel t = new Tafel();

                //put input info in reservering table
                //r.Menu = (from m in db.MenusList where m.Id == reserveringVm.MenuId select m).FirstOrDefault();

                r.MenusList = new List<Menu>();

                    for (int i = 0; i < reserveringVm.Personen; i++)
                {
                    int menuid = Convert.ToInt32(Request.Form["Menu" + i]);
                    r.MenusList.Add((from m in db.Menus where m.Id == menuid select m).FirstOrDefault());


                }
                r.Personen = reserveringVm.Personen;
                r.BeginTijd = reserveringVm.Tijd;
                r.EindTijd = reserveringVm.Tijd.Add(extra);
                r.Datum = reserveringVm.Datum;  
                r.BeginDatum_tijd = reserveringVm.Datum + reserveringVm.Tijd;
                r.EindDatum_tijd = reserveringVm.Datum + reserveringVm.Tijd.Add(extra);
                t.Datum = reserveringVm.Datum;
                t.TafelNummer = reserveringVm.Tafel_Nummer;

                //Get user info
                reserveringVm.contact_Id = currentUser.Id;
                reserveringVm.Contact_Naam = currentUser.Voornaam + " " + currentUser.Achternaam;
                reserveringVm.Contact_Email = currentUser.Email;
                reserveringVm.Contact_Telefoonnummer = currentUser.TelefoonNummer;
                reserveringVm.Prijs = r.MenusList.Sum(m => m.Prijs);

                //put the user info in reservering table
                r.contact_Id = reserveringVm.contact_Id;
                r.Contact_Email = reserveringVm.Contact_Email;
                r.Contact_Naam = reserveringVm.Contact_Naam;
                r.Contact_Telefoonnummer = reserveringVm.Contact_Telefoonnummer;
                r.Totaal_Prijs = reserveringVm.Prijs * reserveringVm.Personen;
                r.Prijs = reserveringVm.Prijs;
                r.Tafel_Nummer = reserveringVm.Tafel_Nummer;

                if (ModelState.IsValid)
                {
                    db.Tafels.Add(t);
                    db.SaveChanges();
                    db.Reserveringen.Add(r);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(reserveringVm);
        }

        // GET: Reservering/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            ReserveringViewModel ReserveringVm = new ReserveringViewModel();

            ReserveringVm.Menus =
            from c in db.Menus
            select new SelectListItem
            {
                Text = c.Naam + " " + c.Prijs,
                Value = c.Id.ToString()
            };

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservering reservering = db.Reserveringen.Find(id);
            if (reservering == null)
            {
                return HttpNotFound();
            }

          //  ReserveringVm.MenuId = reservering.Menu.Id;
            ReserveringVm.Personen = reservering.Personen;
            ReserveringVm.Datum = reservering.Datum;
            ReserveringVm.Tijd = reservering.BeginTijd;

            return View(ReserveringVm);
        }

        // POST: Reservering/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MenuId,Menu,Prijs,Personen,Datum,Tijd")] ReserveringViewModel ReserveringVm)
        {
            Reservering r = (from Reserve in db.Reserveringen where Reserve.Id == ReserveringVm.Id select Reserve).First();
            r.Personen = ReserveringVm.Personen;
            r.Datum = ReserveringVm.Datum;
            r.BeginTijd = ReserveringVm.Tijd;
            r.BeginDatum_tijd = ReserveringVm.Datum + ReserveringVm.Tijd;
            if (ModelState.IsValid)
            {
              //  r.Menu = (from m in db.MenusList where m.Id == ReserveringVm.MenuId select m).FirstOrDefault();
              //  r.Prijs = r.Menu.Prijs;
                r.Totaal_Prijs = r.Prijs * r.Personen;
                //db.Entry(reservering).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ReserveringVm);
        }

        // GET: Reservering/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservering reservering = db.Reserveringen.Find(id);
            if (reservering == null)
            {
                return HttpNotFound();
            }
            return View(reservering);
        }

        // POST: Reservering/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reservering reservering = db.Reserveringen.Find(id);
            db.Reserveringen.Remove(reservering);
            db.SaveChanges();
            return RedirectToAction("Reservering", "AdminIndex");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Plattegrond()
        {
            return View(db.Tafels.ToList());
        }
    }
}
