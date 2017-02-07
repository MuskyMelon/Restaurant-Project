using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kippenbout.Models
{
    public class Menu

    { 
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Menu naam")]
        public virtual string Naam { get; set; }

        [Display(Name = "Voorgerecht")]
        public virtual Gerecht Voorgerecht { get; set; }

        //[ForeignKey("Voorgerecht")]
        //public int VoorgerechtId { get; set; }

        [Display(Name = "Hoofdgerecht")]
        public virtual Gerecht Hoofdgerecht { get; set; }

 
        [Display(Name = "Nagerecht")]
        public virtual Gerecht Nagerecht { get; set; }

        [Display(Name = "Prijs")]
        public virtual Decimal Prijs { get; set; }

        public ICollection<Reservering> MenuReserveringen
        {
            get; set;
        }

        public Menu()
        {
            MenuReserveringen = new List<Reservering>();
        }
    }
}