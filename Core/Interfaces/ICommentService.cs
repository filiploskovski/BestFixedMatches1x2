using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Interfaces
{
    public interface ICommentService
    {
        Task<List<CommentModel>> Index();
    }
}