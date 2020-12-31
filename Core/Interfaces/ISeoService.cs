using System.Threading.Tasks;
using Core.Models;

namespace Core.Interfaces
{
    public interface ISeoService
    {
        Task<SeoModel> SeoByPath(string path);
        Task<SeoLoadModel> Load();
        Task Save_Update(SeoLoadModel model);
        Task Delete(int id);
    }
}