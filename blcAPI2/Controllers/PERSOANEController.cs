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
    public class PERSOANEController : ApiController
    {
        private BLCEntities db = new BLCEntities();

        // GET: api/PERSOANE
        public IQueryable<PERSOANE> GetPERSOANEs()
        {
            return db.PERSOANEs;
        }

        // GET: api/PERSOANE/5
        [ResponseType(typeof(PERSOANE))]
        public IHttpActionResult GetPERSOANE(int id)
        {
            PERSOANE pERSOANE = db.PERSOANEs.Find(id);
            if (pERSOANE == null)
            {
                return NotFound();
            }

            return Ok(pERSOANE);
        }

        // PUT: api/PERSOANE/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPERSOANE(int id, PERSOANE pERSOANE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pERSOANE.P_ID)
            {
                return BadRequest();
            }
            pERSOANE.LIBRARIE = null;
            pERSOANE.CONTRACTEs = null;
            db.Entry(pERSOANE).State = EntityState.Modified;
            if (pERSOANE.P_EMAIL == "") pERSOANE.P_EMAIL = null;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PERSOANEExists(id))
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

        // POST: api/PERSOANE
        [ResponseType(typeof(PERSOANE))]
        public IHttpActionResult PostPERSOANE(PERSOANE pERSOANE)
        {
            try
            {
                if (pERSOANE.P_ID_TYPE == 0) pERSOANE.P_ID_TYPE = null;
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }                
                db.PERSOANEs.Add(pERSOANE);
                db.SaveChanges();

                //return Ok();
                return CreatedAtRoute("DefaultApi", new { id = pERSOANE.P_ID }, pERSOANE);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // DELETE: api/PERSOANE/5
        [ResponseType(typeof(PERSOANE))]
        public IHttpActionResult DeletePERSOANE(int id)
        {
            PERSOANE pERSOANE = db.PERSOANEs.Find(id);
            if (pERSOANE == null)
            {
                return NotFound();
            }

            db.PERSOANEs.Remove(pERSOANE);
            db.SaveChanges();

            return Ok(pERSOANE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PERSOANEExists(int id)
        {
            return db.PERSOANEs.Count(e => e.P_ID == id) > 0;
        }
    }
}