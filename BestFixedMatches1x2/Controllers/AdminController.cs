using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BestFixedMatches1x2.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IControllerActionService _controllerActionService;
        private readonly IHtmlService _htmlService;
        private readonly ISeoService _seoService;
        private readonly IMonthlySubscriptionService _monthlySubscriptionService;
        private readonly IFreeTipsService _freeTipsService;
        private readonly IVipTicketService _vipTicketService;

        public AdminController(IControllerActionService controllerActionService, IHtmlService htmlService,
            ICommentService commentService, ISeoService seoService, IMonthlySubscriptionService monthlySubscriptionService, IFreeTipsService freeTipsService, IVipTicketService vipTicketService)
        {
            _controllerActionService = controllerActionService;
            _htmlService = htmlService;
            _commentService = commentService;
            _seoService = seoService;
            _monthlySubscriptionService = monthlySubscriptionService;
            _freeTipsService = freeTipsService;
            _vipTicketService = vipTicketService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.Controller is AdminController controller)
                controller.ViewBag.BaseModel = await _controllerActionService.LoadBaseModel(context);

            await base.OnActionExecutionAsync(context, next);
        }

        [AllowAnonymous]
        public ViewResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (model.Username == "bestfixedmatches1x2" && model.Password == "losko1969!")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Username)
                };
                var claimsIdentity = new ClaimsIdentity(claims, "Login");

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));
                
                return RedirectToAction("Dashboard");
            }

            return RedirectToAction("Index");
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        #region PageDetails

        public async Task<ViewResult> PageDetails()
        {
            return View(await _htmlService.Load(new HtmlLoadModel()));
        }

        public async Task<IActionResult> PageDetails_GetHTML(HtmlLoadModel model)
        {
            return View("PageDetails", await _htmlService.Load(model));
        }

        public async Task<IActionResult> PageDetails_Save(HtmlLoadModel model)
        {
            await _htmlService.Update(model);
            return RedirectToAction("PageDetails");
        }

        #endregion

        #region CustomerComments

        public async Task<ViewResult> CustomerComments()
        {
            return View(await _commentService.Load());
        }

        public async Task<IActionResult> CustomerComments_Save(CommentLoadModel model)
        {
            await _commentService.Save_Update(model);
            return RedirectToAction("CustomerComments");
        }

        public async Task<IActionResult> CustomerComments_Delete(int id)
        {
            await _commentService.Delete(id);
            return RedirectToAction("CustomerComments");
        }

        #endregion

        #region SEO

        public async Task<ViewResult> Seo()
        {
            return View(await _seoService.Load());
        }

        public async Task<IActionResult> Seo_Save(SeoLoadModel model)
        {
            await _seoService.Save_Update(model);
            return RedirectToAction("Seo");
        }

        public async Task<IActionResult> Seo_Delete(int id)
        {
            await _seoService.Delete(id);
            return RedirectToAction("Seo");
        }

        #endregion

        #region Monthly

        public async Task<ViewResult> MonthlySubscription(int? id)
        {
            if (id == null) return View(await _monthlySubscriptionService.Load(new MonthlySubscriptionModel()));
            return View(await _monthlySubscriptionService.Load(new MonthlySubscriptionModel() { Id = (int)id }));
        }

        public async Task<IActionResult> MonthlySubscription_Save(MonthlySubscriptionModel model)
        {
            await _monthlySubscriptionService.Save_Update(model);
            return RedirectToAction("MonthlySubscription", new { id = model.Id });
        }

        public async Task<IActionResult> MonthlySubscription_Delete(int id)
        {
            await _monthlySubscriptionService.Delete(id);
            return RedirectToAction("MonthlySubscription");
        }

        #endregion

        #region FreeTips

        public async Task<ViewResult> FreeTips(int? id)
        {
            if (id == null) return View(await _freeTipsService.Load(new FreeTipsModel()));
            return View(await _freeTipsService.Load(new FreeTipsModel() { Id = (int)id }));
        }

        public async Task<IActionResult> FreeTips_Save(FreeTipsModel model)
        {
            await _freeTipsService.Save_Update(model);
            return RedirectToAction("FreeTips", new { id = model.Id });
        }

        public async Task<IActionResult> FreeTips_HtmlUpdate(FreeTipsModel model)
        {
            await _freeTipsService.HtmlUpdate(model);
            return RedirectToAction("FreeTips");
        }

        public async Task<IActionResult> FreeTips_Delete(int id)
        {
            await _freeTipsService.Delete(id);
            return RedirectToAction("FreeTips");
        }

        #endregion

        #region VipTicket

        public async Task<ViewResult> VipTicket(int? id)
        {
            if (id == null) return View(await _vipTicketService.Load(new VipTicketLoadModel()));
            return View(await _vipTicketService.Load(new VipTicketLoadModel() { Id = (int)id }));
        }

        public async Task<IActionResult> VipTicket_Save(VipTicketLoadModel model)
        {
            await _vipTicketService.Save_Update(model);
            return RedirectToAction("VipTicket", new { id = model.Id });
        }

        public async Task<IActionResult> VipTicket_HtmlUpdate(VipTicketLoadModel model)
        {
            await _vipTicketService.Save_Html(model);
            return RedirectToAction("VipTicket");
        }

        public async Task<IActionResult> VipTicket_Delete(int id)
        {
            await _vipTicketService.Delete(id);
            return RedirectToAction("VipTicket");
        }

        #endregion
    }
}