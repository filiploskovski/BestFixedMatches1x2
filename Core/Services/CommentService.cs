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
    }
}