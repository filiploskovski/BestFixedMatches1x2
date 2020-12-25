using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public string Name { get; set; }
    }

    public class CommentLoadModel : CommentModel
    {
        public List<CommentModel> Comments { get; set; } = new List<CommentModel>();
    }
}