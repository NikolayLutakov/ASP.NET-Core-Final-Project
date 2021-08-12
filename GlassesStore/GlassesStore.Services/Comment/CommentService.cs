namespace GlassesStore.Services.Comment
{
    using GlassesStore.Data;
    using GlassesStore.Models;
    using Microsoft.EntityFrameworkCore;

    public class CommentService : ICommentService
    {
        private readonly GlassesDbContext data;

        public CommentService(GlassesDbContext data)
        {
            this.data = data;
        }

        public bool Add(string userId, int productId, string content)
        {
            var comment = new Comment()
            {
                UserId = userId,
                Content = content,
                GlassesId = productId
            };

            try
            {
                data.Comments.Add(comment);
                data.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return false;
            }

            return true;
        }

        public bool Delete(int commentId, string userId)
        {
            var commentToDelete = data.Comments.Find(commentId);

            if (commentToDelete == null || commentToDelete.UserId != userId )
            {
                return false;
            }

            try
            {
                data.Comments.Remove(commentToDelete);
                data.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return false;
            }

            return true;
        }
    }
}
