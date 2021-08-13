namespace GlassesStore.Services.Like
{
    using AutoMapper;
    using GlassesStore.Data;
    using GlassesStore.Models;
    using GlassesStore.Services.Like.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper.QueryableExtensions;

    public class LikeService : ILikeService
    {
        private readonly GlassesDbContext data;
        private readonly IMapper mapper;

        public LikeService(GlassesDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public IEnumerable<LikeServiceModel> GetLikesForUser(string userId)
            => data.GlassesLikes
            .Where(x => x.UserId == userId)
            .ProjectTo<LikeServiceModel>(mapper.ConfigurationProvider)
            .ToList();

        public bool IsLiked(int productId, string userId)
        {
            if (data.GlassesLikes.Any(x => x.GlassesId == productId && x.UserId == userId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Like(int productId, string userId)
        {
            if (this.IsLiked(productId, userId))
            {
                return false;
            }

            var like = new GlassesLike
            {
                GlassesId = productId,
                UserId = userId
            };

            try
            {
                data.GlassesLikes.Add(like);
                data.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return false;
            }

            return true;
        }

        public bool Unlike(int productId, string userId)
        {
            if (!this.IsLiked(productId, userId))
            {
                return false;
            }

            var like = data.GlassesLikes
                .Where(x => x.GlassesId == productId && x.UserId == userId)
                .FirstOrDefault();

            if (like == null)
            {
                return false;
            }

            try
            {
                data.GlassesLikes.Remove(like);
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
