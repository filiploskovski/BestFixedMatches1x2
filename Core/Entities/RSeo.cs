using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class RSeo
    {
        public int RSeoId { get; set; }
        public string Page { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
    }
}
