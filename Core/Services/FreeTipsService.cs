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

        public async Task<FreeTipsModel> Load(FreeTipsModel model)
        {
            if (model.Id == 0)
            {
                return new FreeTipsModel()
                {
                    Html = (await _htmlService.HtmlByCode(Const.FT)).Html,
                    Grid = await _freeTipsRepository.GetAllBy(item => item.Map())
                };
            }
            else
            {
                var entity = await _freeTipsRepository.GetById(model.Id);
                return new FreeTipsModel()
                {
                    Date = entity.Date.ToString("yyyy-MM-dd"),
                    Match = entity.Match,
                    Id = entity.RFreeTipId,
                    Description = entity.Description,
                    Result = entity.Result,
                    Odd = entity.Odd,
                    Tip = entity.Tip,
                    WinLose = entity.WinLose,
                    Html = (await _htmlService.HtmlByCode(Const.FT)).Html,
                    Grid = await _freeTipsRepository.GetAllBy(item => item.Map())
                };
            }
        }

        public async Task Save_Update(FreeTipsModel model)
        {
            if (model.Id == 0)
            {
                await _freeTipsRepository.Create(new RFreeTip()
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
                var entity = await _freeTipsRepository.GetById(model.Id);
                entity.Match = model.Match;
                entity.Date = Convert.ToDateTime(model.Date);
                entity.Description = model.Description;
                entity.WinLose = model.WinLose;
                entity.Odd = model.Odd;
                entity.Result = model.Result;
                entity.Tip = model.Tip;
                await _freeTipsRepository.Update(entity);
            }
        }

        public async Task HtmlUpdate(FreeTipsModel model)
        {
            var htmlId = await _htmlService.HtmlByCode(Const.FT);
            await _htmlService.Update(new HtmlLoadModel()
            {
                Id = htmlId.Id,
                Html = model.Html
            });
        }

        public async Task Delete(int id)
        {
            var entity = await _freeTipsRepository.GetById(id);
            if (entity == null) throw new NullReferenceException($"Match with id {id} cannot be found");
            await _freeTipsRepository.Delete(entity);
        }
    }
}