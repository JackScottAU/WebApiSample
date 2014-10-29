using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JackScottAU.WebApiSample.Models
{
    public class Actor
    {
        /// <summary>
        /// Our primary key. If we leave this out EF will still create one behind the scenes, but we won't be able to access it from the code.
        /// </summary>
        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<Movie> StarredIn { get; set; }

        /// <summary>
        /// Creates a new actor. The stork brings it.
        /// </summary>
        public Actor()
        {
            StarredIn = new List<Movie>();
        }
    }
}
