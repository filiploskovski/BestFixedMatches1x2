using System.Threading.Tasks;
using Core.Models;

namespace Core.Interfaces
{
    public interface IHtmlService
    {
        Task<HtmlModel> HtmlByCode(string code);
        Task<HtmlLoadModel> Load(HtmlLoadModel model);
        Task<int> Update(HtmlLoadModel model);
    }
}