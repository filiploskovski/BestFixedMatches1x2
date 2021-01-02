using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Core.Models
{
    public class VipTicketModel
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string ImgUrl { get; set; }
        public string AltTag { get; set; }
        public string Html { get; set; }
    }

    public class VipTicketLoadModel : VipTicketModel
    {
        public IFormFile File { get; set; }
        public List<VipTicketModel> Grid { get; set; } = new List<VipTicketModel>();
    }
}