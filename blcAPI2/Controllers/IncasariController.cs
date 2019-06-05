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