using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VetRS.Models
{
    public class DOB
    {
        [Key]
        public int Id { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Year { get; set; }

    }
}
