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
    public class environmentsController : ApiController
    {
        private requestEntities db = new requestEntities();

        // GET: api/environments
        public IQueryable<environment> Getenvironments()
        {
            return db.environments;
        }

        // GET: api/environments/5
        [ResponseType(typeof(environment))]
        public async Task<IHttpActionResult> Getenvironment(int id)
        {
            environment environment = await db.environments.FindAsync(id);
            if (environment == null)
            {
                return NotFound();
            }

            return Ok(environment);
        }

        // PUT: api/environments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putenvironment(int id, environment environment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != environment.id)
            {
                return BadRequest();
            }

            db.Entry(environment).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!environmentExists(id))
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

        // POST: api/environments
        [ResponseType(typeof(environment))]
        public async Task<IHttpActionResult> Postenvironment(environment environment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.environments.Add(environment);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = environment.id }, environment);
        }

        // DELETE: api/environments/5
        [ResponseType(typeof(environment))]
        public async Task<IHttpActionResult> Deleteenvironment(int id)
        {
            environment environment = await db.environments.FindAsync(id);
            if (environment == null)
            {
                return NotFound();
            }

            db.environments.Remove(environment);
            await db.SaveChangesAsync();

            return Ok(environment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool environmentExists(int id)
        {
            return db.environments.Count(e => e.id == id) > 0;
        }
    }
}