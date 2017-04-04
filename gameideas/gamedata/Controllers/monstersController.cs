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
    public class monstersController : ApiController
    {
        private requestEntities db = new requestEntities();

        // GET: api/monsters
        public IQueryable<monster> Getmonsters()
        {
            return db.monsters;
        }

        // GET: api/monsters/5
        [ResponseType(typeof(monster))]
        public async Task<IHttpActionResult> Getmonster(int id)
        {
            monster monster = await db.monsters.FindAsync(id);
            if (monster == null)
            {
                return NotFound();
            }

            return Ok(monster);
        }

        // PUT: api/monsters/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putmonster(int id, monster monster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != monster.id)
            {
                return BadRequest();
            }

            db.Entry(monster).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!monsterExists(id))
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

        // POST: api/monsters
        [ResponseType(typeof(monster))]
        public async Task<IHttpActionResult> Postmonster(monster monster)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.monsters.Add(monster);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = monster.id }, monster);
        }

        // DELETE: api/monsters/5
        [ResponseType(typeof(monster))]
        public async Task<IHttpActionResult> Deletemonster(int id)
        {
            monster monster = await db.monsters.FindAsync(id);
            if (monster == null)
            {
                return NotFound();
            }

            db.monsters.Remove(monster);
            await db.SaveChangesAsync();

            return Ok(monster);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool monsterExists(int id)
        {
            return db.monsters.Count(e => e.id == id) > 0;
        }
    }
}