using System.Threading.Tasks;
using Core.Code;
using Core.Interfaces;
using Core.Models;

namespace Core.Services
{
    public class IndexService : IIndexService
    {
        private readonly ICommentService _commentService;
        private readonly ICounterService _counterService;
        private readonly IFreeTipsService _freeTipsService;
        private readonly IMonthlySubscriptionService _monthlySubscriptionService;
        private readonly IVipTicketService _vipTicketService;
        private readonly IHtmlService _htmlService;

        public IndexService(ICounterService counterService, IMonthlySubscriptionService monthlySubscriptionService,
            IVipTicketService vipTicketService, ICommentService commentService, IFreeTipsService freeTipsService, IHtmlService htmlService)
        {
            _counterService = counterService;
            _monthlySubscriptionService = monthlySubscriptionService;
            _vipTicketService = vipTicketService;
            _commentService = commentService;
            _freeTipsService = freeTipsService;
            _htmlService = htmlService;
        }


        public async Task<IndexModel> Index()
        {
            var model = new IndexModel
            {
                Free = await _freeTipsService.Index(),
                Monthly = await _monthlySubscriptionService.Index(),
                VipTicket = await _vipTicketService.Index(),
                Comment = await _commentService.Index(),
                Counter = await _counterService.Counter(),
                Landing = await _htmlService.HtmlByCode(Const.LA)
            };

            return await Task.FromResult(model);
        }
    }
}