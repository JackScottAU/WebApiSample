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
    public class MoviesController : ApiController
    {
        private MovieDatabase _db = new MovieDatabase("MovieDB");

        /// <summary>
        /// A list of all the movies.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MovieDTO> Get()
        {
            return _db.Movies.Select(x => new MovieDTO(x)).ToList();
        }

        /// <summary>
        /// Gets a specific movie.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MovieDTO Get(int id)
        {
            Movie movie = _db.Movies.Where(x => x.ID == id).SingleOrDefault();

            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return new MovieDTO(movie);
        }

        /// <summary>
        /// Adds a new movie to the database.
        /// </summary>
        /// <param name="value"></param>
        public void Post([FromBody]MovieDTO value)
        {
            Movie dbMovie = new Movie();
            dbMovie.Name = value.Name;
            dbMovie.Actors = _db.Actors.Where(x => value.Actors.Contains(x.ID)).ToList();

            _db.Movies.Add(dbMovie);
            _db.SaveChanges();
        }

        /// <summary>
        /// Changes an movie.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void Put(int id, [FromBody]MovieDTO value)
        {
            Movie movie = _db.Movies.Where(x => x.ID == id).SingleOrDefault();

            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            movie.Name = value.Name;

            movie.Actors.Clear();
            movie.Actors = _db.Actors.Where(x => value.Actors.Contains(x.ID)).ToList();

            _db.SaveChanges();
        }

        /// <summary>
        /// Deletes a movie record.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            Movie toDelete = _db.Movies.Where(x => x.ID == id).SingleOrDefault();

            if (toDelete == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _db.Movies.Remove(toDelete);
            _db.SaveChanges();
        }
    }
}
