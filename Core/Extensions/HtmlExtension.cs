using System;
using System.Linq;
using Core.Entities;
using Core.Models;

namespace Core.Extensions
{
    public static class HtmlExtension
    {
        public static IQueryable<HtmlModel> Map(this IQueryable<RPageDetails> q, string code)
        {
            return q.Where(item => item.Code.ToLower() == code.ToLower()).Select(
                a => new HtmlModel
                {
                    Code = a.Code,
                    Html = a.Description
                });
        }

        public static IQueryable<HtmlLoadModel> Map(this IQueryable<RPageDetails> q, int id)
        {
            return q.Where(item => item.RPageDetailsId == id).Select(
                a => new HtmlLoadModel()
                {
                    Code = a.Code,
                    Html = a.Description,
                    Id = a.RPageDetailsId
                });
        }

        public static IQueryable<HtmlModel> Map(this IQueryable<RPageDetails> q)
        {
            return q.Select(
                a => new HtmlModel
                {
                    Code = a.Code,
                    Html = a.Description
                });
        }
    }
}