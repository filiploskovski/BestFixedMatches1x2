using System.Threading.Tasks;
using Core.Code;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BestFixedMatches1x2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFreeTipsService _freeTipsService;
        private readonly IHtmlService _htmlService;
        private readonly IIndexService _indexService;
        private readonly IMonthlySubscriptionService _monthlySubscriptionService;
        private readonly IVipTicketService _vipTicketService;
        private readonly IControllerActionService _controllerActionService;

        public HomeController(IIndexService indexService, IVipTicketService vipTicketService,
            IMonthlySubscriptionService monthlySubscriptionService, IFreeTipsService freeTipsService,
            IHtmlService htmlService, IControllerActionService controllerActionService)
        {
            _indexService = indexService;
            _vipTicketService = vipTicketService;
            _monthlySubscriptionService = monthlySubscriptionService;
            _freeTipsService = freeTipsService;
            _htmlService = htmlService;
            _controllerActionService = controllerActionService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.Controller is HomeController controller)
                controller.ViewBag.BaseModel = await _controllerActionService.LoadBaseModel(context);

            await base.OnActionExecutionAsync(context, next);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _indexService.Index());
        }

        public IActionResult Results()
        {
            return View();
        }

        public IActionResult BettingOdds()
        {
            return View();
        }

        public async Task<IActionResult> VipTicketArchive()
        {
            return View(await _vipTicketService.VipTicketArchive());
        }

        public async Task<IActionResult> VipTicketArchiveSingle(int id)
        {
            return View(await _vipTicketService.VipTicketSinge(id));
        }

        public async Task<IActionResult> MonthlySubscriptionArchive()
        {
            return View(await _monthlySubscriptionService.MonthlySubscriptionArchive());
        }

        public async Task<IActionResult> FreeTipsArchive()
        {
            return View(await _freeTipsService.FreeTipsArchive());
        }

        public async Task<IActionResult> About()
        {
            return View(await _htmlService.HtmlByCode(Const.AB));
        }

        public async Task<IActionResult> Advertise()
        {
            return View(await _htmlService.HtmlByCode(Const.ADVERTISE));
        }

        public async Task<IActionResult> ToS()
        {
            return View(await _htmlService.HtmlByCode(Const.TOS));
        }

        public async Task<IActionResult> FAQ()
        {
            return View(await _htmlService.HtmlByCode(Const.FAQ));
        }

        public async Task<IActionResult> Contact()
        {
            return View(await _htmlService.HtmlByCode(Const.CO));
        }
    }
}