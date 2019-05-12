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
using blcAPI2.Models;

namespace blcAPI2.Controllers
{
    public class IncasariController : ApiController
    {
        private BLCEntities db = new BLCEntities();

        // GET: api/Incasari
        public IQueryable<Incasari> GetIncasaris()
        {
            return db.Incasaris;
        }

        // GET: api/Incasari/5
        [ResponseType(typeof(Incasari))]
        public IHttpActionResult GetIncasari(int id)
        {
            Incasari incasari = db.Incasaris.Find(id);
            if (incasari == null)
            {
                return NotFound();
            }

            return Ok(incasari);
        }

        // PUT: api/Incasari/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIncasari(int id, Incasari incasari)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != incasari.c_id)
            {
                return BadRequest();
            }

            db.Entry(incasari).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncasariExists(id))
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

        // POST: api/Incasari
        [ResponseType(typeof(Incasari))]
        public IHttpActionResult PostIncasari(Incasari incasari)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Incasaris.Add(incasari);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (IncasariExists(incasari.c_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = incasari.c_id }, incasari);
        }

        // DELETE: api/Incasari/5
        [ResponseType(typeof(Incasari))]
        public IHttpActionResult DeleteIncasari(int id)
        {
            Incasari incasari = db.Incasaris.Find(id);
            if (incasari == null)
            {
                return NotFound();
            }

            db.Incasaris.Remove(incasari);
            db.SaveChanges();

            return Ok(incasari);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IncasariExists(int id)
        {
            return db.Incasaris.Count(e => e.c_id == id) > 0;
        }
    }
}