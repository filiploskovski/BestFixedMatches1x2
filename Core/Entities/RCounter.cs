using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class RCounter
    {
        public int RCounterId { get; set; }
        public DateTime? Date { get; set; }
        public int? TotalToday { get; set; }
        public int? RealTotalToday { get; set; }
    }
}
