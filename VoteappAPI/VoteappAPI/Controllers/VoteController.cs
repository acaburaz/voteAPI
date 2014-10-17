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
using VoteappAPI.Models;
using VoteappAPI.Context;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace VoteappAPI.Controllers
{
    [AllowCrossSiteJson]
    public class VoteController : ApiController
    {
        private VoteContext db = new VoteContext();

        // GET api/Vote
        public List<Vote> GetVotes()
        {
            var list = db.Votes.ToList();

            return list;
        }

        // GET api/Vote/5
        [ResponseType(typeof(Vote))]
        public IHttpActionResult GetVote(int id)
        {
            Vote vote = db.Votes.Find(id);
            if (vote == null)
            {
                return NotFound();
            }

            return Ok(vote);
        }

        // PUT api/Vote/5
        public IHttpActionResult PutVote(int id, Vote vote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vote.Id)
            {
                return BadRequest();
            }

            db.Entry(vote).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoteExists(id))
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

        // POST api/Vote
        [ResponseType(typeof(Vote))]
        public IHttpActionResult PostVote(Vote vote)
        {
            
            if (!ModelState.IsValid & vote == null)
            {
                return BadRequest(ModelState);
            }
            if (vote.Choices != null)

            {
                if (vote.Choices.ToList().Count > 0)
                {
                    foreach(var c in vote.Choices)
                    {
                        c.Timestamp = DateTime.Today;
                    } 
                      
                }
                 
            }
            db.Votes.Add(vote);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vote.Id }, vote);
        }

        // DELETE api/Vote/5
        [ResponseType(typeof(Vote))]
        public IHttpActionResult DeleteVote(int id,string password)
        {
            Vote vote = db.Votes.Find(id);
            if (vote == null)
            {
                return NotFound();
            }

            db.Votes.Remove(vote);
            db.SaveChanges();

            return Ok(vote);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VoteExists(int id)
        {
            return db.Votes.Count(e => e.Id == id) > 0;
        }
    }
}