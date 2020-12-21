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
                return new SeoModel
                {
                    Title = "Best fixed matches"
                };

            return model;
        }
    }
}