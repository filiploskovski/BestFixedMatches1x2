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
        Task<VipTicketLoadModel> Load(VipTicketLoadModel model);
        Task Save_Update(VipTicketLoadModel model);
        Task Save_Html(VipTicketLoadModel model);
        Task Delete(int id);
    }
}