using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class RComment
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public string Name { get; set; }
    }
}
