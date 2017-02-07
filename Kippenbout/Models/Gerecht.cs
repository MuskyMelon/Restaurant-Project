using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kippenbout.Models
{
    public class Gerecht
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public virtual string Naam { get; set; }

        [Required]
        [Display(Name = "GerechtSoort")]
        public virtual string Soort { get; set; }

        [Required]
        [Display(Name = "Omschrijving")]
        public virtual string Omschrijving { get; set; }

        [Required]
        [Display(Name = "Prijs")]
        public virtual Decimal Prijs { get; set; }
    }

}