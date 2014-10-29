using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JackScottAU.WebApiSample.Models
{
    public class Movie
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public ICollection<Actor> Actors { get; set; }

        public Movie()
        {
            Actors = new List<Actor>();
        }
    }
}
