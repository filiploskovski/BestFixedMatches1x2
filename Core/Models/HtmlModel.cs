using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Core.Models
{
    public class HtmlModel
    {
        public string Code { get; set; }
        public string Html { get; set; }
    }

    public class HtmlLoadModel : HtmlModel
    {
        public int Id { get; set; }
        public List<SelectListItem> Codes { set; get; } = new List<SelectListItem>();
    }
}