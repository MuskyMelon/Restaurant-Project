using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Kippenbout.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Achternaam { get; internal set; }
        public DateTime? Geboortedatum { get; internal set; }
        public int Huisnummer { get; internal set; }
        public string Plaats { get; internal set; }
        public string Postcode { get; internal set; }
        public string StraatNaam { get; internal set; }
        public string TelefoonNummer { get; internal set; }
        public string Toevoegsel { get; internal set; }
        public string Tussenvoegsel { get; internal set; }
        public string Voornaam { get; internal set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        public DbSet<Gerecht> Gerechten { get; set; }
        public DbSet<Menu> Menus { get; set; }
        

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Kippenbout.Models.Reservering> ReserveerModels { get; set; }
    }
}