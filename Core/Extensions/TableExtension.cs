using System.Globalization;
using Core.Entities;
using Core.Models;
using System.Linq;
using Core.Code;

namespace Core.Extensions
{
    public static class TableExtension
    {
        public static IQueryable<TableModel> Map(this IQueryable<RMatch> q)
        {
            return q.Select(item => new TableModel()
            {
                Id = item.RMatchId,
                Date = item.Date.ToString("dd/M/yyyy", CultureInfo.InvariantCulture),
                Description = item.Description,
                Match = item.Match,
                Odd = item.Odd,
                Result = item.Result,
                Tip = item.Tip,
                WinLose = item.WinLose,
                CssClassWinLose = item.WinLose.ToLower() == "win" ? Const.CSS_TABLE_ROW_WIN : Const.CSS_TABLE_ROW_LOSE
            });
        }

        public static IQueryable<TableModel> Map(this IQueryable<RFreeTip> q)
        {
            return q.Select(item => new TableModel()
            {
                Id = item.RFreeTipId,
                Date = item.Date.ToString("dd/M/yyyy", CultureInfo.InvariantCulture),
                Description = item.Description,
                Match = item.Match,
                Odd = item.Odd,
                Result = item.Result,
                Tip = item.Tip,
                WinLose = item.WinLose,
                CssClassWinLose = item.WinLose.ToLower() == "win" ? Const.CSS_TABLE_ROW_WIN : Const.CSS_TABLE_ROW_LOSE
            });
        }
    }
}