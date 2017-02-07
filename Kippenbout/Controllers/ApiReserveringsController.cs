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
    public class ApiReserveringsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ApiReserverings
        public IQueryable<Reservering> GetReserveringen()
        {
            return db.Reserveringen;
        }

        // GET: api/ApiReserverings/5
        [ResponseType(typeof(Reservering))]
        public IHttpActionResult GetReservering(int id)
        {
            Reservering reservering = db.Reserveringen.Find(id);
            if (reservering == null)
            {
                return NotFound();
            }

            return Ok(reservering);
        }

        // PUT: api/ApiReserverings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReservering(int id, Reservering reservering)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reservering.Id)
            {
                return BadRequest();
            }

            db.Entry(reservering).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReserveringExists(id))
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

        // POST: api/ApiReserverings
        [ResponseType(typeof(Reservering))]
        public IHttpActionResult PostReservering(Reservering reservering)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Reserveringen.Add(reservering);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = reservering.Id }, reservering);
        }

        // DELETE: api/ApiReserverings/5
        [ResponseType(typeof(Reservering))]
        public IHttpActionResult DeleteReservering(int id)
        {
            Reservering reservering = db.Reserveringen.Find(id);
            if (reservering == null)
            {
                return NotFound();
            }

            db.Reserveringen.Remove(reservering);
            db.SaveChanges();

            return Ok(reservering);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReserveringExists(int id)
        {
            return db.Reserveringen.Count(e => e.Id == id) > 0;
        }
    }
}