using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VetRS.Models
{
    public class Education
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "First Name", Order = -9)]
        public string FirstName { get; set; }
        [Display(Name = "Last Name", Order = -9)]
        public string LastName { get; set; }
        [Display(Name = "Phone Number", Order = -9)]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        [Display(Name = "Image Location", Order = -9)]
        public string ImageLocation { get; set; }
        [Display(Name = "Program Name", Order = -9)]
        public string ProgramName { get; set; }
        [Display(Name = "Program Location", Order = -9)]
        public string ProgramImageLocation { get; set; }
        [Display(Name = "Program Bio", Order = -9)]
        public string ProgramBio { get; set; }
        [Display(Name = "Education Street", Order = -9)]
        public string EducationStreet { get; set; }
        [Display(Name = "Education City", Order = -9)]
        public string EducationCity { get; set; }
        [Display(Name = "Education State", Order = -9)]
        public string EducationState { get; set; }
        [Display(Name = "Education Zip Code", Order = -9)]
        public int EducationZipCode { get; set; }
        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
