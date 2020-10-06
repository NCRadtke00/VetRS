using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VetRS.Models
{
    public class VeteranView
    {
        [Display(Name = "Name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name = "Contact")]
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
