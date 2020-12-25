using System.Linq;
using Core.Entities;
using Core.Models;

namespace Core.Extensions
{
    public static class CommentExtension
    {
        public static IQueryable<CommentModel> Map(this IQueryable<RComment> q)
        {
            return q.Select(item => new CommentModel()
            {
                Id = item.Id,
                Comment = item.Comment,
                Name = item.Name
            });
        }
    }
}