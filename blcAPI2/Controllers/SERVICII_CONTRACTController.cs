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
    public class SERVICII_CONTRACTController : ApiController
    {
        private BLCEntities db = new BLCEntities();

        // GET: api/SERVICII_CONTRACT
        //public IQueryable<SERVICII_CONTRACT> GetSERVICII_CONTRACT()
        //{
        //    return db.SERVICII_CONTRACT;
        //}

        // GET: api/SERVICII_CONTRACT/5
        //[ResponseType(typeof(SERVICII_CONTRACT))]
        public System.Object GetSERVICII_CONTRACT(int id)
        {
            //var sERVICII_CONTRACT = db.SERVICII_CONTRACT.Where(w => w.SC_C_ID == id);
            var sERVICII_CONTRACT = from l in db.LIBRARIEs
                                    join sc in (from sc in db.SERVICII_CONTRACT where sc.SC_C_ID == id select sc) on l.L_ID equals sc.SC_S_ID into l_sc
                                    from sc in l_sc.DefaultIfEmpty()
                                    where l.L_TIP == "SERVICIU"
                                    select new { SC_C_ID = id, SC_S_ID = sc == null ? 0 : sc.SC_S_ID,
                                        Serviciu = l.L_NUME,
                                        Serv_Id = l.L_ID,
                                        selected = sc == null ? false : true
                                    };
            //var sERVICII_CONTRACT = from l in db.LIBRARIEs
            //                        join sc in db.SERVICII_CONTRACT on new { l.L_ID, id } equals new { sc.SC_S_ID, sc.SC_C_ID } into l_sc
            //                        from sc in l_sc.DefaultIfEmpty()
            //                        where l.L_TIP == "SERVICIU"
            //                        select new { SC_C_ID = sc.SC_C_ID, SC_S_ID = sc.SC_S_ID, selected = sc == null };


            if (sERVICII_CONTRACT == null)
            {
                return NotFound();
            }

            return Ok(sERVICII_CONTRACT);
        }

        //// PUT: api/SERVICII_CONTRACT/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutSERVICII_CONTRACT(int id, SERVICII_CONTRACT sERVICII_CONTRACT)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != sERVICII_CONTRACT.SC_ID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(sERVICII_CONTRACT).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!SERVICII_CONTRACTExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/SERVICII_CONTRACT
        //[ResponseType(typeof(SERVICII_CONTRACT))]
        //public IHttpActionResult PostSERVICII_CONTRACT(SERVICII_CONTRACT sERVICII_CONTRACT)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.SERVICII_CONTRACT.Add(sERVICII_CONTRACT);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = sERVICII_CONTRACT.SC_ID }, sERVICII_CONTRACT);
        //}

        //// DELETE: api/SERVICII_CONTRACT/5
        //[ResponseType(typeof(SERVICII_CONTRACT))]
        //public IHttpActionResult DeleteSERVICII_CONTRACT(int id)
        //{
        //    SERVICII_CONTRACT sERVICII_CONTRACT = db.SERVICII_CONTRACT.Find(id);
        //    if (sERVICII_CONTRACT == null)
        //    {
        //        return NotFound();
        //    }

        //    db.SERVICII_CONTRACT.Remove(sERVICII_CONTRACT);
        //    db.SaveChanges();

        //    return Ok(sERVICII_CONTRACT);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SERVICII_CONTRACTExists(int id)
        {
            return db.SERVICII_CONTRACT.Count(e => e.SC_ID == id) > 0;
        }
    }
}