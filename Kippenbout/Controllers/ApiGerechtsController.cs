using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Kippenbout.Models;

namespace Kippenbout.Controllers
{
    public class ApiGerechtsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ApiGerechts
        public IQueryable<Gerecht> GetGerechten()
        {
            return db.Gerechten;
        }

        // GET: api/ApiGerechts/5
        [ResponseType(typeof(Gerecht))]
        public IHttpActionResult GetGerecht(int id)
        {
            Gerecht gerecht = db.Gerechten.Find(id);
            if (gerecht == null)
            {
                return NotFound();
            }

            return Ok(gerecht);
        }

        // PUT: api/ApiGerechts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGerecht(int id, Gerecht gerecht)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gerecht.Id)
            {
                return BadRequest();
            }

            db.Entry(gerecht).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GerechtExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ApiGerechts
        [ResponseType(typeof(Gerecht))]
        public IHttpActionResult PostGerecht(Gerecht gerecht)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Gerechten.Add(gerecht);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gerecht.Id }, gerecht);
        }

        // DELETE: api/ApiGerechts/5
        [ResponseType(typeof(Gerecht))]
        public IHttpActionResult DeleteGerecht(int id)
        {
            Gerecht gerecht = db.Gerechten.Find(id);
            if (gerecht == null)
            {
                return NotFound();
            }

            db.Gerechten.Remove(gerecht);
            db.SaveChanges();

            return Ok(gerecht);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GerechtExists(int id)
        {
            return db.Gerechten.Count(e => e.Id == id) > 0;
        }
    }
}