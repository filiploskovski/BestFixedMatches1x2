using System.Threading.Tasks;
using Core.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Core.Interfaces
{
    public interface IControllerActionService
    {
        Task<BaseModel> LoadBaseModel(ActionExecutingContext context);
    }
}