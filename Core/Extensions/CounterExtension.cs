using System.Linq;
using Core.Entities;
using Core.Models;

namespace Core.Extensions
{
    public static class CounterExtension
    {
        public static IQueryable<int> Map(this IQueryable<RCounter> q)
        {
            return q.Select(item => (int)item.RealTotalToday);
        }
    }
}