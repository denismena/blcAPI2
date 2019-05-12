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
    public class LIBRARIEController : ApiController
    {
        private BLCEntities db = new BLCEntities();

        // GET: api/LIBRARIE
        //public IQueryable<LibrarieView> GetLIBRARIEs()
        //{
        //    var result = from l in db.LIBRARIEs
        //                 select new
        //                 {
        //                     L_ID= l.L_ID,
        //                     L_NUME =l.L_NUME,
        //                     L_TIP=l.L_TIP
        //                 };
        //    return result.ToList();
        //}

        public System.Object GetLIBRARIEs()
        {
            var result = from l in db.LIBRARIEs
                         select new
                         {
                             l.L_ID,
                             l.L_NUME,
                             l.L_TIP
                         };
            return result.ToList();
        }

        // GET: api/LIBRARIE/5
        [ResponseType(typeof(LIBRARIE))]
        public IHttpActionResult GetLIBRARIE(int id)
        {
            LIBRARIE lIBRARIE = db.LIBRARIEs.Find(id);
            if (lIBRARIE == null)
            {
                return NotFound();
            }

            return Ok(lIBRARIE);
        }

        // PUT: api/LIBRARIE/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLIBRARIE(int id, LIBRARIE lIBRARIE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lIBRARIE.L_ID)
            {
                return BadRequest();
            }

            db.Entry(lIBRARIE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LIBRARIEExists(id))
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

        // POST: api/LIBRARIE
        [ResponseType(typeof(LIBRARIE))]
        public IHttpActionResult PostLIBRARIE(LIBRARIE lIBRARIE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LIBRARIEs.Add(lIBRARIE);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lIBRARIE.L_ID }, lIBRARIE);
        }

        // DELETE: api/LIBRARIE/5
        [ResponseType(typeof(LIBRARIE))]
        public IHttpActionResult DeleteLIBRARIE(int id)
        {
            LIBRARIE lIBRARIE = db.LIBRARIEs.Find(id);
            if (lIBRARIE == null)
            {
                return NotFound();
            }

            db.LIBRARIEs.Remove(lIBRARIE);
            db.SaveChanges();

            return Ok(lIBRARIE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LIBRARIEExists(int id)
        {
            return db.LIBRARIEs.Count(e => e.L_ID == id) > 0;
        }
    }
}