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

    }
}
