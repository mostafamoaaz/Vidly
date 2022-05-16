using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace Vidly.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.FavActors = new List<Actor>();
            this.FavMovies = new List<Movie>();
            this.FavDirectors = new List<Director>();
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public string ProfileImageUrl { get; set; }

        public virtual ICollection<Movie> FavMovies { get; set; }

        public virtual ICollection<Actor> FavActors { get; set; }

        public virtual ICollection<Director> FavDirectors { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Vidly.Models.Actor> Actors { get; set; }

        public System.Data.Entity.DbSet<Vidly.Models.Director> Directors { get; set; }

        public System.Data.Entity.DbSet<Vidly.Models.Movie> Movies { get; set; }
    }
}