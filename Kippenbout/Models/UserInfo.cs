using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kippenbout.Models
{
    public class UserInfo
    {
        [Required]
        public string Voornaam { get; set; }

        public string Tussenvoegsel { get; set; }

        [Required]
        public string Achternaam { get; set; }

        [Required]
        public string Plaats { get; set; }

        [Required]
        public string Straatnaam { get; set; }

        [Required]
        public int Huisnummer { get; set; }


        public string Toevoegsel { get; set; }

        [Required]
        public string Postcode { get; set; }

        [Display(Name = "Geboortedatum")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Geboortedatum { get; set; }

        [Display(Name = "Telefoonnummer")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Niet een geldig telefoonnummer")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}