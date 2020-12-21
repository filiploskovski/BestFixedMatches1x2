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
    public class MonthlySubscriptionService : IMonthlySubscriptionService
    {
        private readonly IHtmlService _htmlService;
        private readonly IRepository<RMatch> _matchRepository;

        public MonthlySubscriptionService(IRepository<RMatch> matchRepository, IHtmlService htmlService)
        {
            _matchRepository = matchRepository;
            _htmlService = htmlService;
        }

        public async Task<Tuple<HtmlModel, List<TableModel>>> Index()
        {
            return new Tuple<HtmlModel, List<TableModel>>(await _htmlService.HtmlByCode(Const.MS),
                await _matchRepository.GetAllBy(q => q.OrderByDescending(x => x.Date).Take(30).Map()));
        }

        public async Task<Tuple<HtmlModel, List<TableModel>>> MonthlySubscriptionArchive()
        {
            return new Tuple<HtmlModel, List<TableModel>>(await _htmlService.HtmlByCode(Const.MSA),
                await _matchRepository.GetAllBy(q => q.OrderByDescending(x => x.Date).Map()));
        }
    }
}