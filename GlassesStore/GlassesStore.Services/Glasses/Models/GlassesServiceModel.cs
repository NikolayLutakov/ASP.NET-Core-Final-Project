using GlassesStore.Services.Comment.Models;
using System.Collections.Generic;

namespace GlassesStore.Services.Glasses.Models
{
    public class GlassesServiceModel
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public decimal Rating { get; set; }
        public int PurchasesCount { get; set; }
        public IEnumerable<CommentServiceModel> Comments { get; set; }
    }
}
