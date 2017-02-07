using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kippenbout.Models
{
    public class Tafel
    {
        [Key]
        public int Id { get; set; }

        public string TafelNummer { get; set; }

        public DateTime Datum { get; set; }

    }
}