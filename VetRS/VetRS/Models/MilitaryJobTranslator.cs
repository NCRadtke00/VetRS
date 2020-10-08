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
        public string MilitarySpecialtyNumber { get; set; }
        public string MilitaryJobTitle { get; set; }

        public string CivilianJobTitle { get; set; }




    }
}
