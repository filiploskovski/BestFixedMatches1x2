using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Interfaces
{
    public interface IVipTicketService
    {
        Task<Tuple<HtmlModel, List<VipTicketModel>>> Index();
        Task<Tuple<HtmlModel, List<VipTicketModel>>> VipTicketArchive();
        Task<Tuple<HtmlModel, VipTicketModel>> VipTicketSinge(int id);
    }
}