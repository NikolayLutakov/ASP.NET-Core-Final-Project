namespace GlassesStore.Data
{
    using GlassesStore.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    public class GlassesDbContext : IdentityDbContext<User>
    {
        public GlassesDbContext(DbContextOptions<GlassesDbContext> options)
            : base(options)
        {
        }
        public DbSet<Brand> Brands { get; set; }

        public DbSet<Card> Cards { get; set; }

        public DbSet<CardType> CardTypes { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Glasses> Glasses { get; set; }

        public DbSet<GlassesRating> GlassesRatings { get; set; }

        public DbSet<GlassesType> GlassesTypes { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Glasses>(glasseses =>
            {
                glasseses.HasKey(x => x.Id);

                glasseses.Property(p => p.Price).HasPrecision(18,2);
            });


            builder.Entity<GlassesType>(glassesType =>
            {
                glassesType.HasKey(x => x.Id);

                glassesType.HasMany(x => x.Glasses)
                .WithOne(x => x.Type)
                .HasForeignKey(x => x.TypeId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Brand>(brand =>
            {
                brand.HasKey(x => x.Id);

                brand.HasMany(x => x.Glasses)
                .WithOne(x => x.Brand)
                .HasForeignKey(x => x.BrandId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<GlassesRating>(glassesRating =>
            {
                glassesRating.HasKey(x => new
                {
                    x.UserId,
                    x.GlassesId
                });

                glassesRating.HasOne(x => x.Glasses)
                    .WithMany(x => x.GlassesRatings)
                    .HasForeignKey(x => x.GlassesId)
                    .OnDelete(DeleteBehavior.Restrict);


                glassesRating.HasOne(x => x.User)
                    .WithMany(x => x.GlassesRatings)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });


            builder.Entity<Purchase>(purchase =>
            {
                purchase.HasKey(x => x.Id);

                purchase.HasOne(x => x.Glasses)
                    .WithMany(x => x.Purchases)
                    .HasForeignKey(x => x.GlassesId)
                    .OnDelete(DeleteBehavior.Restrict);

                purchase.HasOne(x => x.Card)
                    .WithMany(x => x.Purchases)
                    .HasForeignKey(x => x.CardId)
                    .OnDelete(DeleteBehavior.Restrict);
            });


            builder.Entity<Comment>(comment =>
            {
                comment.HasKey(x => x.Id);

                comment.HasOne(x => x.Glasses)
                    .WithMany(x => x.Comments)
                    .HasForeignKey(x => x.GlassesId)
                    .OnDelete(DeleteBehavior.Restrict);

                comment.HasOne(x => x.User)
                    .WithMany(x => x.Comments)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(builder);
        }
    }
}
