using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetRS.Models
{
    public class ChatRoom
    {
        public int Id { get; set; }
        public virtual ICollection<ChatRoomUser> ChatRoomUsers { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
