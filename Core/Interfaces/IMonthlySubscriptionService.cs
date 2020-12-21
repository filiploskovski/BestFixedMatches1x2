using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Interfaces
{
    public interface IMonthlySubscriptionService
    {
        Task<Tuple<HtmlModel, List<TableModel>>> Index();
        Task<Tuple<HtmlModel, List<TableModel>>> MonthlySubscriptionArchive();
    }
}