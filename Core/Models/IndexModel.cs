using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class IndexModel
    {
        public Tuple<HtmlModel, List<TableModel>> Monthly { get; set; }
        public Tuple<HtmlModel, List<TableModel>> Free { get; set; }
        
        public Tuple<HtmlModel,List<VipTicketModel>> VipTicket { get; set; }
        public List<CommentModel> Comment { get; set; } = new List<CommentModel>();
        public CounterModel Counter { get; set; } = new CounterModel();
        public HtmlModel Landing { get; set; } = new HtmlModel();
    }
}