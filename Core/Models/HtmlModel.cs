using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Core.Models
{
    public class HtmlModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Html { get; set; }
    }

    public class HtmlLoadModel : HtmlModel
    {
        public List<SelectListItem> Codes { set; get; } = new List<SelectListItem>();
    }
}