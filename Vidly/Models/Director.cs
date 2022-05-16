using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Director
    {
        public Director()
        {

        }
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Age { get; set; }

        public List<Movie> Movies { get; set; }

    }
}