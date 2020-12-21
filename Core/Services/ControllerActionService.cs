using System.Threading.Tasks;
using Core.Code;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Core.Services
{
    public class ControllerActionService : IControllerActionService
    {
        private readonly ISeoService _seoService;
        private readonly IHtmlService _htmlService;

        public ControllerActionService(ISeoService seoService, IHtmlService htmlService)
        {
            _seoService = seoService;
            _htmlService = htmlService;
        }

        public async Task<BaseModel> LoadBaseModel(ActionExecutingContext context)
        {
            return new BaseModel
            {
                Seo = await _seoService.SeoByPath(context.HttpContext.Request.Path),
                Footer = new FooterModel {Html = await _htmlService.HtmlByCode(Const.FOO)}
            };
        }
    }
}