using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public Movie()
        {
            /*
            this.Id = 
            this.Actors = 
            this.Reviews = 
            */
        }
        
        public int Id { get; set; }

        public string Name { get; set; }

        public string GeneralImageUrl { get; set; }

        public string DirectorId { get; set; }


        public Director Director { get; set; }

        public List<Actor> Actors { get; set; }

        public List<String> Reviews { get; set; }
        
        [NotMapped]
        public HttpPostedFileBase picture { get; set; }

    }
}