using System;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Extensions;
using Core.Interfaces;
using Core.Models;
using Shared.DbInit.Repository;

namespace Core.Services
{
    public class SeoService : ISeoService
    {
        private readonly IRepository<RSeo> _seoRepository;

        public SeoService(IRepository<RSeo> seoRepository)
        {
            _seoRepository = seoRepository;
        }

        public async Task<SeoModel> SeoByPath(string path)
        {
            var isEndingOnNumber = false;
            if (path != null) isEndingOnNumber = char.IsDigit(path[path.Length - 1]);

            if (isEndingOnNumber) return new SeoModel();

            var model = await _seoRepository.GetFirstBy(q =>
                q.Where(item => item.Page.ToLower() == path.ToLower()).Map());

            if (model == null)
            {
                return new SeoModel
                {
                    Title = "Best fixed matches",
                    Description = "",
                    Keywords = "",
                };
            }

            return model;
        }

        public async Task<SeoLoadModel> Load()
        {
            return new SeoLoadModel()
            {
                SeoByPage = await _seoRepository.GetAllBy(item => item.Map())
            };
        }

        public async Task Save_Update(SeoLoadModel model)
        {
            if (model.Id == 0)
            {
                await _seoRepository.Create(new RSeo()
                {
                    Page = model.Page,
                    Title = model.Title,
                    Description = model.Description,
                    Keywords = model.Keywords
                });
                return;
            }
            else
            {
                var entity = await _seoRepository.GetFirstBy(item => item.Where(q => q.RSeoId == model.Id));
                if (entity == null) throw new NullReferenceException($"Cannot find entity with id {model.Id}");
                entity.Page = model.Page;
                entity.Title = model.Title;
                entity.Description = model.Description;
                entity.Keywords = model.Keywords;
                await _seoRepository.Update(entity);
            }
        }

        public async Task Delete(int id)
        {
            var entity = await _seoRepository.GetFirstBy(item => item.Where(q => q.RSeoId == id));
            if (entity == null) throw new NullReferenceException($"Cannot find entity with id {id}");
            await _seoRepository.Delete(entity);
        }
    }
}