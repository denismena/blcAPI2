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
        //public IQueryable<CONTRACTE> GetCONTRACTEs()
        //{
        //    return db.CONTRACTEs;
        //}
        public System.Object GetCONTRACTEs()
        {
            var result = from c in db.CONTRACTEs
                         select new
                         {
                             c.C_ID,
                             c.C_NUMAR,
                             c.C_DATA,
                             c.PERSOANE.P_NUME,
                             c.PERSOANE.P_PRENUME,
                             c.C_NR_PERS,
                             c.C_NR_ADULTI,
                             c.C_TARA
                            ,
                             c.C_ORAS
                            ,
                             c.C_DE_LA_DATA
                            ,
                             c.C_PANA_LA_DATA
                            ,
                             c.C_HOTEL
                            ,
                             c.C_HOTEL_STELE
                            ,
                             c.C_MENTIUNI
                            ,
                             c.C_PRET
                            ,
                             c.C_MONEDA
                            ,
                             c.C_AVANS
                            ,
                             c.C_DATA_DIFERENTA
                            ,
                             c.C_FACTURA
                            ,
                             c.C_CHITANTA
                            ,
                             c.C_AVANS_DATA
                            ,
                             c.C_AVANS2_DATA
                            ,
                             c.C_AVANS2
                            ,
                             c.C_FACTURA2
                            ,
                             c.C_CHITANTA2
                            ,
                             c.C_DATA_DIFERENTA2
                            ,
                             c.C_AVANS3_DATA
                            ,
                             c.C_AVANS3
                            ,
                             c.C_FACTURA3
                            ,
                             c.C_CHITANTA3
                            ,
                             c.C_DATA_DIFERENTA3
                         };
            return result.ToList();
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

            var oldSerList = db.SERVICII_CONTRACT.Where(w => w.SC_C_ID == id).Select(s => s.SC_S_ID).ToArray(); ;
            var newSerList = cONTRACTE.SERVICII_CONTRACT.Select(s => s.SC_S_ID).ToArray();

            var toAdd = newSerList.Except(oldSerList);
            //var toDelete = oldSerList.Except(newSerList).Select(s=>s.SC_S_ID).ToArray();
            var toDelete = oldSerList.Except(newSerList);

            cONTRACTE.PERSOANE = null;
            cONTRACTE.LIBRARIE = null;
            cONTRACTE.SERVICII_CONTRACT = null;
            db.Entry(cONTRACTE).State = EntityState.Modified;

            try
            {
                //add new services
                var addService = new SERVICII_CONTRACT();
                foreach (var sc in toAdd)
                {
                    addService = new SERVICII_CONTRACT();
                    addService.SC_C_ID = id;
                    addService.SC_S_ID = sc;
                    db.SERVICII_CONTRACT.Add(addService);
                }

                //delete services
                foreach (var scd in toDelete)
                {
                    db.SERVICII_CONTRACT.Remove(db.SERVICII_CONTRACT.Where(w => w.SC_S_ID == scd && w.SC_C_ID == id).FirstOrDefault());
                }
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
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            try
            {
                //Contracte
                db.CONTRACTEs.Add(cONTRACTE);

                //Servicii
                foreach(var sc in cONTRACTE.SERVICII_CONTRACT)
                {
                    db.SERVICII_CONTRACT.Add(sc);
                }
                db.SaveChanges();

                return CreatedAtRoute("DefaultApi", new { id = cONTRACTE.C_ID }, cONTRACTE);
            }
            catch(Exception ex)
            { throw ex; }
            
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