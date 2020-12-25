using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Extensions;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shared.DbInit.Repository;

namespace Core.Services
{
    public class HtmlService : IHtmlService
    {
        private readonly IRepository<RPageDetails> _pageDetailsRepository;

        public HtmlService(IRepository<RPageDetails> pageDetailsRepository)
        {
            _pageDetailsRepository = pageDetailsRepository;
        }

        public async Task<HtmlModel> HtmlByCode(string code)
        {
            return await _pageDetailsRepository.GetFirstBy(item => item.Map(code));
        }

        public async Task<HtmlLoadModel> Load(HtmlLoadModel model)
        {
            if (model.Id == 0)
            {
            }
            else
            {
                model = await GetById(model.Id);
            }

            model.Codes = await Lookup();
            return model;
        }


        public async Task<int> Update(HtmlLoadModel model)
        {
            var entity = await _pageDetailsRepository.GetById(model.Id);
            if(entity == null) throw new NullReferenceException("Cannot find HTML !!!");
            entity.Description = model.Html;
            await _pageDetailsRepository.Update(entity);
            return entity.RPageDetailsId;
        }

        public async Task<HtmlLoadModel> GetById(int id)
        {
            var model = await _pageDetailsRepository.GetFirstBy(item => item.Map(id));
            return model;
        }

        private async Task<List<SelectListItem>> Lookup()
        {
            return await _pageDetailsRepository.GetAllBy(q => q.Select(item => new SelectListItem
            {
                Text = item.Name,
                Value = item.RPageDetailsId.ToString()
            }));
        }
    }
}