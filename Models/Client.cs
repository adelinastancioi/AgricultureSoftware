using System;
using System.Collections.Generic;

#nullable disable

namespace AgriSoft.Models
{
    public partial class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string ClientType { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string Purchases { get; set; }
        public decimal? Qtty { get; set; }
        public string Date { get; set; }
    }
}
