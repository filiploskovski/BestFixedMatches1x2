using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class RVipTicket
    {
        public int RVipTicketId { get; set; }
        public DateTime Date { get; set; }
        public string Img { get; set; }
        public bool? FirstPage { get; set; }
        public string Alt { get; set; }
    }
}
