using System.Threading.Tasks;
using Core.Models;

namespace Core.Interfaces
{
    public interface ISeoService
    {
        Task<SeoModel> SeoByPath(string path);
    }
}