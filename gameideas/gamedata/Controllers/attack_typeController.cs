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
    public class attack_typeController : ApiController
    {
        private requestEntities db = new requestEntities();

        // GET: api/attack_type
        public IQueryable<attack_type> Getattack_type()
        {
            return db.attack_type;
        }

        // GET: api/attack_type/5
        [ResponseType(typeof(attack_type))]
        public async Task<IHttpActionResult> Getattack_type(int id)
        {
            attack_type attack_type = await db.attack_type.FindAsync(id);
            if (attack_type == null)
            {
                return NotFound();
            }

            return Ok(attack_type);
        }

        // PUT: api/attack_type/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putattack_type(int id, attack_type attack_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != attack_type.id)
            {
                return BadRequest();
            }

            db.Entry(attack_type).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!attack_typeExists(id))
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

        // POST: api/attack_type
        [ResponseType(typeof(attack_type))]
        public async Task<IHttpActionResult> Postattack_type(attack_type attack_type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.attack_type.Add(attack_type);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = attack_type.id }, attack_type);
        }

        // DELETE: api/attack_type/5
        [ResponseType(typeof(attack_type))]
        public async Task<IHttpActionResult> Deleteattack_type(int id)
        {
            attack_type attack_type = await db.attack_type.FindAsync(id);
            if (attack_type == null)
            {
                return NotFound();
            }

            db.attack_type.Remove(attack_type);
            await db.SaveChangesAsync();

            return Ok(attack_type);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool attack_typeExists(int id)
        {
            return db.attack_type.Count(e => e.id == id) > 0;
        }
    }
}