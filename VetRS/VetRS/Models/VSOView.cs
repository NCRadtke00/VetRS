using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VetRS.Models
{
    public class VSOView
    {
        [Display(Name = "Name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name = "Contact")]
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        [Display(Name = "Street Address")]
        public string VSOStreet { get; set; }
        public string VSOCity { get; set; }
        public string VSOState { get; set; }
       

        [Display(Name = "Zip Code")]
        public int VSOZipCode { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

    }
}
