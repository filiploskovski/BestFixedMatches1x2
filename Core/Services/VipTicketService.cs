using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Code;
using Core.Entities;
using Core.Extensions;
using Core.Interfaces;
using Core.Models;
using Shared.DbInit.Repository;

namespace Core.Services
{
    public class VipTicketService : IVipTicketService
    {
        private readonly IHtmlService _htmlService;
        private readonly IRepository<RVipTicket> _vipTicketRepository;

        public VipTicketService(IHtmlService htmlService, IRepository<RVipTicket> vipTicketRepository)
        {
            _htmlService = htmlService;
            _vipTicketRepository = vipTicketRepository;
        }

        public async Task<Tuple<HtmlModel, List<VipTicketModel>>> Index()
        {
            return new Tuple<HtmlModel, List<VipTicketModel>>(await _htmlService.HtmlByCode(Const.VT),
                await _vipTicketRepository.GetAllBy(q => q.OrderByDescending(x => x.Date).Take(4).Map()));
        }

        public async Task<Tuple<HtmlModel, List<VipTicketModel>>> VipTicketArchive()
        {
            return new Tuple<HtmlModel, List<VipTicketModel>>(await _htmlService.HtmlByCode(Const.VTA),
                await _vipTicketRepository.GetAllBy(q => q.OrderByDescending(x => x.Date).Map()));
        }

        public async Task<Tuple<HtmlModel, VipTicketModel>> VipTicketSinge(int id)
        {
            var model = await _vipTicketRepository.GetFirstBy(item => item.Where(q => q.RVipTicketId == id).Map());
            if(model == null) throw new NullReferenceException("Id not found !!! Init tracking id address");
            return new Tuple<HtmlModel, VipTicketModel>(await _htmlService.HtmlByCode(Const.VTA), model);
        }
    }
}