﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    [Table("Message2s")]
    public class Message2
    {
        [Key]
        public int MessageID { get; set; }

        public int? SenderID { get; set; }

        public int? ReceiverID { get; set; }

        public string? subject { get; set; }

        public string? MessageDetails { get; set; }

        public DateTime MessageDate { get; set; }

        public bool MessageStatus { get; set; }


        public Writer SenderUser { get; set; }  
        public Writer ReceiverUser { get; set; }  
    }
}
