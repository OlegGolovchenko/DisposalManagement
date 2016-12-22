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
using DisposalManagement.Models;
using DisposalManagement.MailSender;

namespace DisposalManagement.Controllers
{
    public class RequestsController : ApiController
    {
        private DisposalManagementContext db = new DisposalManagementContext();

        // GET: api/Requests
        public IQueryable<Request> GetRequests()
        {
            return db.Requests;
        }

        // GET: api/Requests/5
        [ResponseType(typeof(Request))]
        public IHttpActionResult GetRequest(int id)
        {
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return NotFound();
            }

            return Ok(request);
        }

        // PUT: api/Requests/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRequest(int id, Request request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != request.Id)
            {
                return BadRequest();
            }

            db.Entry(request).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(id))
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

        // POST: api/Requests
        [ResponseType(typeof(Request))]
        public IHttpActionResult PostRequest(Request request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Sender sender = new Sender();
            sender.send(request.ClientEmail, "Uw aanvraag is aangekregen","Uw aanvrag is aangekomen en zal zo snel mogelijk verwerkt worden.");
            db.Requests.Add(request);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = request.Id }, request);
        }

        // DELETE: api/Requests/5
        [ResponseType(typeof(Request))]
        public IHttpActionResult DeleteRequest(int id)
        {
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return NotFound();
            }

            db.Requests.Remove(request);
            db.SaveChanges();

            return Ok(request);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RequestExists(int id)
        {
            return db.Requests.Count(e => e.Id == id) > 0;
        }
    }
}