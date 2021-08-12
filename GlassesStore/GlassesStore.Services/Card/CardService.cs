namespace GlassesStore.Services.Card
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using GlassesStore.Data;
    using GlassesStore.Services.Card.Models;

    public class CardService : ICardService
    {
        private readonly GlassesDbContext data;
        private readonly IMapper mapper;

        public CardService(GlassesDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public IEnumerable<CardServiceModel> GetCardsForUser(string id)
            => data.Cards
            .Where(x => x.UserId == id).ProjectTo<CardServiceModel>(mapper.ConfigurationProvider)
            .ToList();
    }
}
