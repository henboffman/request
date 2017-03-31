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
    public class weapon_typesController : ApiController
    {
        private requestEntities db = new requestEntities();

        // GET: api/weapon_types
        public IQueryable<weapon_types> Getweapon_types()
        {
            try
            {
                return db.weapon_types;
            }
            catch (Exception error)
            {
                throw error;
            }
            
        }

        // GET: api/weapon_types/5
        [ResponseType(typeof(weapon_types))]
        public async Task<IHttpActionResult> Getweapon_types(int id)
        {
            weapon_types weapon_types = await db.weapon_types.FindAsync(id);
            if (weapon_types == null)
            {
                return NotFound();
            }

            return Ok(weapon_types);
        }

        // PUT: api/weapon_types/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putweapon_types(int id, weapon_types weapon_types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != weapon_types.id)
            {
                return BadRequest();
            }

            db.Entry(weapon_types).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!weapon_typesExists(id))
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

        // POST: api/weapon_types
        [ResponseType(typeof(weapon_types))]
        public async Task<IHttpActionResult> Postweapon_types(weapon_types weapon_types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.weapon_types.Add(weapon_types);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = weapon_types.id }, weapon_types);
        }

        // DELETE: api/weapon_types/5
        [ResponseType(typeof(weapon_types))]
        public async Task<IHttpActionResult> Deleteweapon_types(int id)
        {
            weapon_types weapon_types = await db.weapon_types.FindAsync(id);
            if (weapon_types == null)
            {
                return NotFound();
            }

            db.weapon_types.Remove(weapon_types);
            await db.SaveChangesAsync();

            return Ok(weapon_types);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool weapon_typesExists(int id)
        {
            return db.weapon_types.Count(e => e.id == id) > 0;
        }
    }
}