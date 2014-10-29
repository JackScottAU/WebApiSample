using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using JackScottAU.WebApiSample.Models;

namespace JackScottAU.WebApiSample.TransferObjects
{
    public class MovieDTO
    {
        /// <summary>
        /// The database identifier.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The name of the movie.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// The actors who are in this movie.
        /// </summary>
        public int[] Actors { get; set; }

        public MovieDTO()
        {

        }

        public MovieDTO(Movie source)
        {
            ID = source.ID;
            Name = source.Name;
            Actors = source.Actors.Select(x => x.ID).ToArray();
        }
    }
}