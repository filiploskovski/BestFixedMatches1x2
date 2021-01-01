using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Interfaces
{
    public interface IFreeTipsService
    {
        Task<Tuple<HtmlModel, List<TableModel>>> Index();
        Task<Tuple<HtmlModel, List<TableModel>>> FreeTipsArchive();
        Task<FreeTipsModel> Load(FreeTipsModel model);
        Task Save_Update(FreeTipsModel model);
        Task HtmlUpdate(FreeTipsModel model);
        Task Delete(int id);
    }
}