namespace GlassesStore.Services.Comment
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using GlassesStore.Data;
    using GlassesStore.Models;
    using GlassesStore.Services.Comment.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class CommentService : ICommentService
    {
        private readonly GlassesDbContext data;
        private readonly IMapper mapper;

        public CommentService(GlassesDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public bool Add(
            string userId, 
            int productId, 
            string content)
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

        public bool Edit(
            int commentId,
            string userId, 
            int productId, 
            string content)
        {
            var comment = data.Comments.Find(commentId);

            if (comment == null || comment.UserId != userId)
            {
                return false;
            }

            comment.Content = content;

            try
            {
                data.Comments.Update(comment);
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

        public CommentServiceModel GetById(int id)
            => data.Comments
            .Where(x => x.Id == id)
            .ProjectTo<CommentServiceModel>(mapper.ConfigurationProvider)
            .FirstOrDefault();
        
    }
}
