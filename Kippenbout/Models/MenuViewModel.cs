using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kippenbout.Models
{
    public class MenuViewModel
    {
        public virtual int Id { get; set; }
        public virtual string Naam { get; set; }
        public virtual int VoorgerechtId { get; set;  }
        public virtual IEnumerable<SelectListItem> Voorgerechten { get; set; }
        public virtual int HoofdgerechtId { get; set; }
        public virtual IEnumerable<SelectListItem> Hoofdgerechten { get; set; }
        public virtual int NagerechtId { get; set; }
        public virtual IEnumerable<SelectListItem> Nagerechten { get; set; }
        public virtual Decimal Prijs { get; set; }
    }
}