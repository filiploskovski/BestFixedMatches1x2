using System.Linq;
using Core.Entities;
using Core.Models;

namespace Core.Extensions
{
    public static class SeoExtension
    {
        public static IQueryable<SeoModel> Map(this IQueryable<RSeo> q)
        {
            return q.Select(item => new SeoModel()
                {
                    Title = item.Title,
                });
        }
    }
}