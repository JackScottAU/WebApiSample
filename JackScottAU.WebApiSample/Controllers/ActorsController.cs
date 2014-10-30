using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JackScottAU.WebApiSample.Models;
using JackScottAU.WebApiSample.TransferObjects;

namespace JackScottAU.WebApiSample.Controllers
{
    public class ActorsController : ApiController
    {
        private MovieDatabase _db = new MovieDatabase("MovieDB");

        /// <summary>
        /// Returns all the actors.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ActorDTO> Get()
        {
            return _db.Actors.ToList().Select(x => new ActorDTO(x)).ToList();
        }

        /// <summary>
        /// Gets a specific actor.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActorDTO Get(int id)
        {
            Actor actor = _db.Actors.Where(x => x.ID == id).SingleOrDefault();

            if (actor == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            
            return new ActorDTO(actor);
        }

        /// <summary>
        /// Adds a new actor to the database.
        /// </summary>
        /// <param name="value"></param>
        public void Post([FromBody]ActorDTO value)
        {
            Actor dbActor = new Actor();
            dbActor.Name = value.Name;
            dbActor.DateOfBirth = value.DateOfBirth;
            dbActor.StarredIn = _db.Movies.Where(x => value.StarredIn.Contains(x.ID)).ToList();

            _db.Actors.Add(dbActor);
            _db.SaveChanges();
        }

        /// <summary>
        /// Changes an actor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void Put(int id, [FromBody]ActorDTO value)
        {
            Actor actor = _db.Actors.Where(x => x.ID == id).SingleOrDefault();

            if (actor == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            actor.Name = value.Name;
            actor.DateOfBirth = value.DateOfBirth;

            actor.StarredIn.Clear();
            actor.StarredIn = _db.Movies.Where(x => value.StarredIn.Contains(x.ID)).ToList();

            _db.SaveChanges();
        }

        /// <summary>
        /// Deletes an actor.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            Actor toDelete = _db.Actors.Where(x => x.ID == id).SingleOrDefault();

            if (toDelete == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _db.Actors.Remove(toDelete);
            _db.SaveChanges();
        }

        private ActorDTO ConvertToDTO(Actor actor)
        {
            return new ActorDTO(actor);
        }
    }
}
