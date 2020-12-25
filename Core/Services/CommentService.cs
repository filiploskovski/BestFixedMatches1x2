using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Extensions;
using Core.Interfaces;
using Core.Models;
using Shared.DbInit.Repository;

namespace Core.Services
{
    public class CommentService : ICommentService
    {
        private readonly IRepository<RComment> _commentRepository;

        public CommentService(IRepository<RComment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<List<CommentModel>> Index()
        {
            return await _commentRepository.GetAllBy(item => item.Map());
        }

        public async Task<CommentLoadModel> Load()
        {
            var model = new CommentLoadModel()
            {
                Comments = await _commentRepository.GetAllBy(item => item.Map())
            };
            return model;
        }

        public async Task<int> Save_Update(CommentLoadModel model)
        {
            if (model.Id == 0)
            {
                var entity = await _commentRepository.Create(new RComment()
                {
                    Comment = model.Comment,
                    Name = model.Name
                });
                return entity.Id;
            }

            var e = await _commentRepository.GetById(model.Id);
            e.Comment = model.Comment;
            e.Name = model.Name;
            await _commentRepository.Update(e);
            return e.Id;

        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _commentRepository.GetById(id);
            await _commentRepository.Delete(entity);
            return true;
        }
    }
}