using System.Globalization;
using Core.Entities;
using Core.Models;
using System.Linq;

namespace Core.Extensions
{
    public static class TableExtension
    {
        public static IQueryable<TableModel> Map(this IQueryable<RMatch> q)
        {
            return q.Select(item => new TableModel()
            {
               Date = item.Date.ToString("dd/M/yyyy", CultureInfo.InvariantCulture),
               Description = item.Description,
               Match = item.Match,
               Odd = item.Odd,
               Result = item.Result,
               Tip = item.Tip,
               WinLose = item.WinLose
            });
        }

        public static IQueryable<TableModel> Map(this IQueryable<RFreeTip> q)
        {
            return q.Select(item => new TableModel()
            {
                Date = item.Date.ToString("dd/M/yyyy", CultureInfo.InvariantCulture),
                Description = item.Description,
                Match = item.Match,
                Odd = item.Odd,
                Result = item.Result,
                Tip = item.Tip,
                WinLose = item.WinLose
            });
        }
    }
}