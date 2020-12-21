using System.Threading.Tasks;
using Core.Entities;
using Core.Extensions;
using Core.Interfaces;
using Core.Models;
using Shared.DbInit.Repository;

namespace Core.Services
{
    public class HtmlService : IHtmlService
    {
        private readonly IRepository<RPageDetails> _pageDetails;

        public HtmlService(IRepository<RPageDetails> pageDetails)
        {
            _pageDetails = pageDetails;
        }

        public async Task<HtmlModel> HtmlByCode(string code)
        {
            return await _pageDetails.GetFirstBy(item => item.Map(code));
        }
    }
}