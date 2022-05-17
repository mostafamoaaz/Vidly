using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vidly.Models
{
    public class UserAccount
    {
        [Key]
        public int Id { get; set; }                                     //id

        [Required(ErrorMessage = "Name is required")]
        public string FirstName { get; set; }                           //first name

        [Required(ErrorMessage = "Name is required")]
        public string LastName { get; set; }                            //last name

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",ErrorMessage = "Email is invaled")]
        public string Email  { get; set; }                              //email

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }                            //password

        [Compare("Password", ErrorMessage = "Password is not matched")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }                     //confirm password

        public string ProfileImageUrl { get; set; }                     //profile picture

        public List<Movie> FavMovies { get; set; }

        public List<Actor> FavActors { get; set; }

        public List<Director> FavDirectors { get; set; }

        [NotMapped]
        public HttpPostedFileBase picture { get; set; }
    }
}