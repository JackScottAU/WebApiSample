using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JackScottAU.WebApiSample.Models;
using System.ComponentModel.DataAnnotations;

namespace JackScottAU.WebApiSample.TransferObjects
{
    public class ActorDTO
    {
        /// <summary>
        /// The actor's database identifier.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// The actor's full name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// When the actor was born.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// IDs of movies the actor is in.
        /// </summary>
        public int[] StarredIn { get; set; }


        public ActorDTO()
        {

        }

        public ActorDTO(Actor source)
        {
            ID = source.ID;
            Name = source.Name;
            DateOfBirth = source.DateOfBirth;
            StarredIn = source.StarredIn.Select(x => x.ID).ToArray();
        }
    }
}
