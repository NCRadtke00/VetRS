using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetRS.Models
{
    public class Message
    {
        public int ID { get; set; }
        public string SentBy { get; set; }
        public string Messages { get; set; }
        public int GroupId { get; set; }
    }
}
