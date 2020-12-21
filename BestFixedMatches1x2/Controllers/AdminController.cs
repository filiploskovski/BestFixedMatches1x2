using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BestFixedMatches1x2.Controllers
{
    public class AdminController : Controller
    {
        private readonly IControllerActionService _controllerActionService;

        public AdminController(IControllerActionService controllerActionService)
        {
            _controllerActionService = controllerActionService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.Controller is AdminController controller)
                controller.ViewBag.BaseModel = await _controllerActionService.LoadBaseModel(context);

            await base.OnActionExecutionAsync(context, next);
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public async Task<IActionResult> PageDetails(string code)
        {
            return View();
        }
    }
}