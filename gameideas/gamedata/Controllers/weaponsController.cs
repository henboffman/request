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
    [RoutePrefix("api/weapons")]
    public class weaponsController : ApiController
    {
        private requestEntities db = new requestEntities();

        // GET: api/weapons
        public IQueryable<weapon> Getweapons()
        {
            return db.weapons;
        }

        [HttpGet]
        [Route("spawnWeapon")]
        public weapon SpawnWeapon()
        {
            //get random weapon from database
            var weaponCount = db.weapons.Count();
            Random random = new Random();
            int itemId = random.Next(1, weaponCount);

            weapon returnedWeapon = db.weapons.Find(itemId);
            return returnedWeapon;

        }

        // GET: api/weapons/5
        [ResponseType(typeof(weapon))]
        public async Task<IHttpActionResult> Getweapon(int id)
        {
            weapon weapon = await db.weapons.FindAsync(id);
            if (weapon == null)
            {
                return NotFound();
            }

            return Ok(weapon);
        }

        // PUT: api/weapons/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putweapon(int id, weapon weapon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != weapon.id)
            {
                return BadRequest();
            }

            db.Entry(weapon).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!weaponExists(id))
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

        // POST: api/weapons
        [ResponseType(typeof(weapon))]
        public async Task<IHttpActionResult> Postweapon(weapon weapon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.weapons.Add(weapon);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = weapon.id }, weapon);
        }

        // DELETE: api/weapons/5
        [ResponseType(typeof(weapon))]
        public async Task<IHttpActionResult> Deleteweapon(int id)
        {
            weapon weapon = await db.weapons.FindAsync(id);
            if (weapon == null)
            {
                return NotFound();
            }

            db.weapons.Remove(weapon);
            await db.SaveChangesAsync();

            return Ok(weapon);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool weaponExists(int id)
        {
            return db.weapons.Count(e => e.id == id) > 0;
        }
    }
}