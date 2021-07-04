using System;
using System.Collections.Generic;

#nullable disable

namespace AgriSoft.Models
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public string Title { get; set; }
        public string Mail { get; set; }
        public string Text { get; set; }
    }
}
