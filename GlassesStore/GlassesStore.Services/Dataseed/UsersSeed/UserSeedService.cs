namespace GlassesStore.Services.Dataseed.UsersSeed
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using GlassesStore.Data;
    using GlassesStore.Models;
    using static GlassesStore.Constants.Constants.AdministratorConstants;

    public class UserSeedService : IUserSeedService
    {
        private readonly GlassesDbContext data;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public UserSeedService(
            GlassesDbContext data,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.data = data;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public void Seed()
        {
            Task
                 .Run(async () =>
                 {
                     if (await roleManager.RoleExistsAsync(AdministratorRoleName))
                     {
                         return;
                     }

                     var role = new IdentityRole { Name = AdministratorRoleName };

                     await roleManager.CreateAsync(role);

                     var admin = new User
                     {
                         Email = AdministratorUsername,
                         UserName = AdministratorUsername
                     };

                     var user1 = new User
                     {
                         Email = "user1@user.com",
                         UserName = "user1@user.com"
                     };

                     var user2 = new User
                     {
                         Email = "user2@user.com",
                         UserName = "user2@user.com"
                     };

                     var cardTypes = data.CardTypes.ToList();

                     var adminCards = new Card[2];
                     var user1Cards = new Card[2];
                     var user2Cards = new Card[2];

                     if (cardTypes != null)
                     {
                         adminCards[0] = new Card
                         {
                             Number = "3405919467259721",
                             ExpiresOn = DateTime.Parse("2025-05-01"),
                             Type = cardTypes[0]

                         };

                         adminCards[1] = new Card
                         {
                             Number = "3764754601231772",
                             ExpiresOn = DateTime.Parse("2026-01-01"),
                             Type = cardTypes[1]
                         };

                         user1Cards[0] = new Card
                         {
                             Number = "3751982887368458",
                             ExpiresOn = DateTime.Parse("2024-07-01"),
                             Type = cardTypes[0]

                         };

                         user1Cards[1] = new Card
                         {
                             Number = "3744480942404873",
                             ExpiresOn = DateTime.Parse("2025-02-01"),
                             Type = cardTypes[1]
                         };

                         user2Cards[0] = new Card
                         {
                             Number = "3717435159122992",
                             ExpiresOn = DateTime.Parse("2022-01-01"),
                             Type = cardTypes[0]

                         };

                         user2Cards[1] = new Card
                         {
                             Number = "3786253553563105",
                             ExpiresOn = DateTime.Parse("2023-04-01"),
                             Type = cardTypes[1]
                         };

                         admin.Cards = adminCards;
                         user1.Cards = user1Cards;
                         user2.Cards = user2Cards;
                     }

                     await userManager.CreateAsync(admin, AdministratorPassword);

                     await userManager.CreateAsync(user1, AdministratorPassword);

                     await userManager.CreateAsync(user2, AdministratorPassword);

                     await userManager.AddToRoleAsync(admin, role.Name);
                 })
                 .GetAwaiter()
                 .GetResult();
        }
    }
}
