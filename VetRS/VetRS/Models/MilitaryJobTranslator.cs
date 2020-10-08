using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VetRS.Models
{
    public class MilitaryJobTranslator
    {
        [Key]
        [Display(Name = "Military Specialty Number", Order = -9)]
        public string MilitarySpecialtyNumber { get; set; }
        [Display(Name = "Military Job Title", Order = -9)]
        public string MilitaryJobTitle { get; set; }
        [Display(Name = "Civilian Job Title", Order = -9)]
        public string CivilianJobTitle { get; set; }




    }
}
