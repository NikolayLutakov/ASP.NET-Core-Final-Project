using GlassesStore.Services.Like.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassesStore.Services.Like
{
    public interface ILikeService
    {
        bool Like(int productId, string userId);

        bool Unlike(int productId, string userId);

        bool IsLiked(int productId, string userId);

        IEnumerable<LikeServiceModel> GetLikesForUser(string userId);
    }
}
