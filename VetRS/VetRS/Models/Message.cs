﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetRS.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }

        [ForeignKey("SenderUser")]
        public int SenderId { get; set; }
        public virtual User SenderUser { get; set; }

        [ForeignKey("RecipientUser")]
        public int RecipientId { get; set; }
        public virtual User RecipientUser { get; set; }

        public int ChatRoomId { get; set; }
        public virtual ChatRoom ChatRoom { get; set; }
    }
}
