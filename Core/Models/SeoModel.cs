using System.Collections.Generic;

namespace Core.Models
{
    public class SeoModel
    {
        public int Id { get; set; }
        public string Page { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
    }

    public class SeoLoadModel : SeoModel
    {
        public List<SeoModel> SeoByPage { get; set; } = new List<SeoModel>();
    }
}