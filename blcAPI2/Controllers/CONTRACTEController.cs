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
    public class CONTRACTEController : ApiController
    {
        private BLCEntities db = new BLCEntities();

        // GET: api/CONTRACTE
        public IQueryable<CONTRACTE> GetCONTRACTEs()
        {
            return db.CONTRACTEs;
        }

        // GET: api/CONTRACTE/5
        [ResponseType(typeof(CONTRACTE))]
        public IHttpActionResult GetCONTRACTE(int id)
        {
            CONTRACTE cONTRACTE = db.CONTRACTEs.Find(id);
            if (cONTRACTE == null)
            {
                return NotFound();
            }

            return Ok(cONTRACTE);
        }

        // PUT: api/CONTRACTE/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCONTRACTE(int id, CONTRACTE cONTRACTE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cONTRACTE.C_ID)
            {
                return BadRequest();
            }

            db.Entry(cONTRACTE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CONTRACTEExists(id))
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

        // POST: api/CONTRACTE
        [ResponseType(typeof(CONTRACTE))]
        public IHttpActionResult PostCONTRACTE(CONTRACTE cONTRACTE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CONTRACTEs.Add(cONTRACTE);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cONTRACTE.C_ID }, cONTRACTE);
        }

        // DELETE: api/CONTRACTE/5
        [ResponseType(typeof(CONTRACTE))]
        public IHttpActionResult DeleteCONTRACTE(int id)
        {
            CONTRACTE cONTRACTE = db.CONTRACTEs.Find(id);
            if (cONTRACTE == null)
            {
                return NotFound();
            }

            db.CONTRACTEs.Remove(cONTRACTE);
            db.SaveChanges();

            return Ok(cONTRACTE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CONTRACTEExists(int id)
        {
            return db.CONTRACTEs.Count(e => e.C_ID == id) > 0;
        }
    }
}