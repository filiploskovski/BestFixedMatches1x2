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
    public class FreeTipsService : IFreeTipsService
    {
        private readonly IHtmlService _htmlService;
        private readonly IRepository<RFreeTip> _freeTipsRepository;

        public FreeTipsService(IHtmlService htmlService, IRepository<RFreeTip> freeTipsRepository)
        {
            _htmlService = htmlService;
            _freeTipsRepository = freeTipsRepository;
        }

        public async Task<Tuple<HtmlModel, List<TableModel>>> Index()
        {
            return new Tuple<HtmlModel, List<TableModel>>(await _htmlService.HtmlByCode(Const.FT),
                await _freeTipsRepository.GetAllBy(q => q.OrderByDescending(x => x.Date).Take(30).Map()));
        }

        public async Task<Tuple<HtmlModel, List<TableModel>>> FreeTipsArchive()
        {
            return new Tuple<HtmlModel, List<TableModel>>(await _htmlService.HtmlByCode(Const.FTA),
                await _freeTipsRepository.GetAllBy(q => q.OrderByDescending(x => x.Date).Map()));
        }
    }
}