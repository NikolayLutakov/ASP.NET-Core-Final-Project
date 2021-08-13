using GlassesStore.Services.Comment.Models;
using GlassesStore.Services.Like.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassesStore.Web.Models.Shop
{
    public class GlassesDetailsViewModel
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public IEnumerable<LikeServiceModel> Likes { get; set; }
        public int PurchasesCount { get; set; }
        public IEnumerable<CommentServiceModel> Comments { get; set; }
    }
}
