using System;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BestFixedMatches1x2.Controllers
{
    public class AdminController : Controller
    {
        private readonly IControllerActionService _controllerActionService;
        private readonly IHtmlService _htmlService;
        private readonly ICommentService _commentService;

        public AdminController(IControllerActionService controllerActionService, IHtmlService htmlService, ICommentService commentService)
        {
            _controllerActionService = controllerActionService;
            _htmlService = htmlService;
            _commentService = commentService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.Controller is AdminController controller)
                controller.ViewBag.BaseModel = await _controllerActionService.LoadBaseModel(context);

            await base.OnActionExecutionAsync(context, next);
        }

        public IActionResult Index()
        {
            return RedirectToAction("Dashboard");
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
    }
}