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

        public async Task<MonthlySubscriptionModel> Load(MonthlySubscriptionModel model)
        {
            if (model.Id == 0)
            {
                return new MonthlySubscriptionModel()
                {
                    Grid = await _matchRepository.GetAllBy(query => query.OrderByDescending(x => x.Date).Map())
                };
            }
            else
            {
                var entity = await _matchRepository.GetFirstBy(qq => qq.Where(q => q.RMatchId == model.Id));
                return new MonthlySubscriptionModel()
                {
                    Grid = await _matchRepository.GetAllBy(query => query.OrderByDescending(x => x.Date).Map()),
                    Date = entity.Date.ToString("yyyy-MM-dd"),
                    Match = entity.Match,
                    Id = entity.RMatchId,
                    Description = entity.Description,
                    Result = entity.Result,
                    Odd = entity.Odd,
                    Tip = entity.Tip,
                    WinLose = entity.WinLose
                };
            }
        }

        public async Task Save_Update(MonthlySubscriptionModel model)
        {
            if (model.Id == 0)
            {
                await _matchRepository.Create(new RMatch()
                {
                    Match = model.Match,
                    Date = Convert.ToDateTime(model.Date),
                    Description = model.Description,
                    WinLose = model.WinLose,
                    Odd = model.Odd,
                    Result = model.Result,
                    Tip = model.Tip
                });
            }
            else
            {
                var entity = await _matchRepository.GetFirstBy(item => item.Where(q => q.RMatchId == model.Id));
                if (entity == null) throw new NullReferenceException($"Match with id {model.Id} cannot be found");
                entity.Match = model.Match;
                entity.Date = Convert.ToDateTime(model.Date);
                entity.Description = model.Description;
                entity.WinLose = model.WinLose;
                entity.Odd = model.Odd;
                entity.Result = model.Result;
                entity.Tip = model.Tip;
                await _matchRepository.Update(entity);
            }
        }

        public async Task Delete(int id)
        {
            var entity = await _matchRepository.GetFirstBy(item => item.Where(q => q.RMatchId == id));
            if (entity == null) throw new NullReferenceException($"Match with id {id} cannot be found");
            await _matchRepository.Delete(entity);
        }
    }
}