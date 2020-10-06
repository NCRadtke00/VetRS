using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VetRS.Models
{
    public class EducationView
    {
        [Display(Name = "Name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Display(Name = "Contact")]
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        [Display(Name = "Program Name")]
        public string ProgramName { get; set; }

        [Display(Name = "Program Bio")]
        public string ProgramBio { get; set; }

        [Display(Name = "Street Address")]
        public string EducationStreet { get; set; }
        public string EducationCity { get; set; }
        public string EducationState { get; set; }

        [Display(Name = "Zip Code")]
        public int EducationZipCode { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
