using System.Globalization;
using System.IO;
using System.Linq;
using Core.Entities;
using Core.Models;

namespace Core.Extensions
{
    public static class VipTicketExtension
    {
        public static IQueryable<VipTicketModel> Map(this IQueryable<RVipTicket> q)
        {
            return q.Select(item => new VipTicketModel()
            {
                Id = item.RVipTicketId,
                Date = item.Date.ToString("dd/M/yyyy", CultureInfo.InvariantCulture),
                AltTag = item.Alt,
                ImgUrl = item.Img
            });
        }
    }
}