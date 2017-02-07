using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kippenbout.Models
{
    public class ReserveringViewModel
    {
        public virtual int Id { get; set; }
        public virtual int MenuId { get; set; }

        public virtual IEnumerable<SelectListItem> Menus { get; set; }

        public virtual List<Reservering> Reservering { get; set; }

        public virtual int Personen { get; set; }

        [Display(Name = "Datum")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public virtual DateTime Datum { get; set; }

        [Display(Name = "Tijd")]
        [DataType(DataType.Time), DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public virtual TimeSpan Tijd { get; set; }

        [Required]
        public virtual string Tafel_Nummer { get; set; }

        public virtual string contact_Id { get; set; }

        public virtual string Contact_Naam { get; set; }

        public virtual string Contact_Email { get; set; }

        public virtual string Contact_Telefoonnummer { get; set; }

        public virtual Decimal Prijs { get; set; }


    }
}