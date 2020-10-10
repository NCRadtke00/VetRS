using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetRS.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

     
        [InverseProperty("SenderUser")]
        public virtual ICollection<Message> Senders { get; set; }
        [InverseProperty("RecipientUser")]
        public virtual ICollection<Message> Recipients { get; set; }
        public virtual ICollection<ChatRoomUser> ChatRoomUsers { get; set; }
    }
}
