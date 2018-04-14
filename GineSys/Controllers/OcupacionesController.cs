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
using GineSys.Models;

namespace GineSys.Controllers
{
    public class OcupacionesController : ApiController
    {
        private GineSysDbContext db = new GineSysDbContext();

        // GET: api/Ocupaciones
        public IHttpActionResult GetOcupaciones()
        {
            return Ok(db.Ocupaciones);
        }

        // GET: api/Ocupaciones/5
        [ResponseType(typeof(Ocupacion))]
        public IHttpActionResult GetOcupacion(int id)
        {
            Ocupacion ocupacion = db.Ocupaciones.Find(id);
            if (ocupacion == null)
            {
                return NotFound();
            }

            return Ok(ocupacion);
        }

        // PUT: api/Ocupaciones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOcupacion(int id, Ocupacion ocupacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ocupacion.OcupacionId)
            {
                return BadRequest();
            }

            db.Entry(ocupacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OcupacionExists(id))
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

        // POST: api/Ocupaciones
        [ResponseType(typeof(Ocupacion))]
        public IHttpActionResult PostOcupacion(Ocupacion ocupacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ocupaciones.Add(ocupacion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = ocupacion.OcupacionId }, ocupacion);
        }

        // DELETE: api/Ocupaciones/5
        [ResponseType(typeof(Ocupacion))]
        public IHttpActionResult DeleteOcupacion(int id)
        {
            Ocupacion ocupacion = db.Ocupaciones.Find(id);
            if (ocupacion == null)
            {
                return NotFound();
            }

            db.Ocupaciones.Remove(ocupacion);
            db.SaveChanges();

            return Ok(ocupacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OcupacionExists(int id)
        {
            return db.Ocupaciones.Count(e => e.OcupacionId == id) > 0;
        }
    }
}