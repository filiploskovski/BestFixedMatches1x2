using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class RSeoDetails
    {
        public int RSeoDetailsId { get; set; }
        public string Page { get; set; }
        public string Keywords { get; set; }
        public string RelatedKeyword { get; set; }
        public string Img { get; set; }
        public string ImgAlt { get; set; }
        public string Text { get; set; }
    }
}
