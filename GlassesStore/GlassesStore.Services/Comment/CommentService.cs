namespace GlassesStore.Services.Comment
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using GlassesStore.Data;
    using GlassesStore.Models;
    using GlassesStore.Services.Comment.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using static GlassesStore.Models.Common.Constants.AdministratorConstants;

    public class CommentService : ICommentService
    {
        private readonly GlassesDbContext data;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public CommentService(GlassesDbContext data, IMapper mapper, UserManager<User> userManager)
        {
            this.data = data;
            this.mapper = mapper;
            this.userManager = userManager;
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
            var user = data.Users.Find(userId);

            if (comment == null || (comment.UserId != userId && !userManager.IsInRoleAsync(user, AdministratorRoleName).GetAwaiter().GetResult()))
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
            var user = data.Users.Find(userId);

            if (commentToDelete == null || (commentToDelete.UserId != userId && !userManager.IsInRoleAsync(user, AdministratorRoleName).GetAwaiter().GetResult()))
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

        public IEnumerable<CommentServiceModel> GetCommentsForUser(string id)
            => data.Comments
            .Where(x => x.UserId == id)
            .OrderByDescending(x => x.CreatedOn)
            .ProjectTo<CommentServiceModel>(mapper.ConfigurationProvider)
            .ToList();

        public IEnumerable<CommentServiceModel> All()
        => data.Comments
            .OrderByDescending(x => x.CreatedOn)
            .ProjectTo<CommentServiceModel>(mapper.ConfigurationProvider)
            .ToList();
    }
}
