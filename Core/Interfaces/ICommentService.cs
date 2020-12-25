using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Interfaces
{
    public interface ICommentService
    {
        Task<List<CommentModel>> Index();
        Task<CommentLoadModel> Load();
        Task<int> Save_Update(CommentLoadModel model);
        Task<bool> Delete(int id);
    }
}