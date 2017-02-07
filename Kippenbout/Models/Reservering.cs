using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kippenbout.Models
{
    public class Reservering
    {
        public int Id { get; set; }

        [Display(Name = "Kies uw Menu")]
        [Required]
        public virtual List<Menu> MenusList { get; set; }

        [Display(Name="Aantal Personen")]
        [Required]
        public virtual int Personen { get; set; }
        [Required]
        public virtual DateTime Datum { get; set; }
        [Required]
        public virtual TimeSpan BeginTijd { get; set; }

        public virtual TimeSpan EindTijd { get; set; }

        public virtual DateTime BeginDatum_tijd { get; set; }

        public virtual DateTime EindDatum_tijd { get; set; }

        public virtual string contact_Id { get; set; }

        [Required]
        public virtual string Tafel_Nummer { get; set; }

        public virtual string Contact_Naam { get; set; }

        public virtual string Contact_Email { get; set; }

        public virtual string Contact_Telefoonnummer { get; set; }

       
        public virtual bool Gerecht_Klaar { get; set; }

        public virtual Decimal Prijs { get; set; }

        public virtual Decimal Totaal_Prijs { get; set; }

        public ICollection<Menu> ReserveringMenus
        {
            get; set;
        }

        public Reservering()
        {
            ReserveringMenus = new List<Menu>();
        }

    }
}