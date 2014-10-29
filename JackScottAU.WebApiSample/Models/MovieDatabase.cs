using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JackScottAU.WebApiSample.Models
{
    public class MovieDatabase : DbContext
    {
        public MovieDatabase(string connectionName) : base(connectionName) { }

        /// <summary>
        /// The "Movies" table.
        /// </summary>
        public DbSet<Movie> Movies { get; set; }

        /// <summary>
        /// The "Actors" table.
        /// </summary>
        public DbSet<Actor> Actors { get; set; }
    }
}
