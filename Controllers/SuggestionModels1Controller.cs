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
using SuggestionBox.Models;

namespace SuggestionBox.Controllers
{
    public class SuggestionModels1Controller : ApiController
    {
        private SuggestionBoxContext db = new SuggestionBoxContext();

        // GET: api/SuggestionModels1
        public IQueryable<SuggestionModel> GetSuggestionModels()
        {
            return db.SuggestionModels;
        }

        // GET: api/SuggestionModels1/5
        [ResponseType(typeof(SuggestionModel))]
        public IHttpActionResult GetSuggestionModel(int id)
        {
            SuggestionModel suggestionModel = db.SuggestionModels.Find(id);
            if (suggestionModel == null)
            {
                return NotFound();
            }

            return Ok(suggestionModel);
        }

        // PUT: api/SuggestionModels1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSuggestionModel(int id, SuggestionModel suggestionModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != suggestionModel.RecordNum)
            {
                return BadRequest();
            }

            db.Entry(suggestionModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuggestionModelExists(id))
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

        // POST: api/SuggestionModels1
        [ResponseType(typeof(SuggestionModel))]
        public IHttpActionResult PostSuggestionModel(SuggestionModel suggestionModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SuggestionModels.Add(suggestionModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = suggestionModel.RecordNum }, suggestionModel);
        }

        // DELETE: api/SuggestionModels1/5
        [ResponseType(typeof(SuggestionModel))]
        public IHttpActionResult DeleteSuggestionModel(int id)
        {
            SuggestionModel suggestionModel = db.SuggestionModels.Find(id);
            if (suggestionModel == null)
            {
                return NotFound();
            }

            db.SuggestionModels.Remove(suggestionModel);
            db.SaveChanges();

            return Ok(suggestionModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SuggestionModelExists(int id)
        {
            return db.SuggestionModels.Count(e => e.RecordNum == id) > 0;
        }
    }
}