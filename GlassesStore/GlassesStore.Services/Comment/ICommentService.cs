using GlassesStore.Services.Comment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassesStore.Services.Comment
{
    public interface ICommentService
    {
        CommentServiceModel GetById(int id);

        bool Add(
            string userId, 
            int productId, 
            string content);

        bool Delete(int commentId, string userId);

        public bool Edit(
                int commentId,
                string userId,
                int productId,
                string content);
    }
}
