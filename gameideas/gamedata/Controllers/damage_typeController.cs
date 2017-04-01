using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using gamedata;

namespace gamedata.Controllers
{
    public class damage_typeController : ApiController
    {
        private requestEntities db = new requestEntities();

        // GET: api/damage_type
        public IQueryable<damage_type> Getdamage_type()
        {
            return db.damage_type;
        }

        // GET: api/damage_type/5
        [ResponseType(typeof(damage_type))]
        public async Task<IHttpActionResult> Getdamage_type(int id)
        {
            damage_type damage_type = await db.damage_type.FindAsync(id);
            if (damage_type == null)
            {
                return NotFound();
            }

            return Ok(damage_type);
        }

        // PUT: api/damage_type/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putdamage_type(int id, damage_type damage_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != damage_type.id)
            {
                return BadRequest();
            }

            db.Entry(damage_type).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!damage_typeExists(id))
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

        // POST: api/damage_type
        [ResponseType(typeof(damage_type))]
        public async Task<IHttpActionResult> Postdamage_type(damage_type damage_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.damage_type.Add(damage_type);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = damage_type.id }, damage_type);
        }

        // DELETE: api/damage_type/5
        [ResponseType(typeof(damage_type))]
        public async Task<IHttpActionResult> Deletedamage_type(int id)
        {
            damage_type damage_type = await db.damage_type.FindAsync(id);
            if (damage_type == null)
            {
                return NotFound();
            }

            db.damage_type.Remove(damage_type);
            await db.SaveChangesAsync();

            return Ok(damage_type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool damage_typeExists(int id)
        {
            return db.damage_type.Count(e => e.id == id) > 0;
        }
    }
}