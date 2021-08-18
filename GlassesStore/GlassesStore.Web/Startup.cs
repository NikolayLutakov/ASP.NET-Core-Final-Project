namespace GlassesStore.Web
{
    using System.Globalization;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using GlassesStore.Data;
    using GlassesStore.Models;
    using GlassesStore.Services.Brand;
    using GlassesStore.Services.Glasses;
    using GlassesStore.Services.GlassesType;
    using GlassesStore.Services.Users;
    using GlassesStore.Web.Infrastructure.Extensions;
    using GlassesStore.Services.Card;
    using GlassesStore.Services.Comment;
    using GlassesStore.Services.Like;
    using GlassesStore.Services.Dataseed.UsersSeed;
    using GlassesStore.Services.Dataseed.GlassesTypesSeed;
    using GlassesStore.Services.Dataseed.CardTypesSeed;
    using GlassesStore.Services.Dataseed.BrandSeed;
    using GlassesStore.Services.Dataseed.GlassesSeed;
    using GlassesStore.Services.Contacts;
    using GlassesStore.Services.Dataseed.ContactMessage;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GlassesDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();


            services
               .AddDefaultIdentity<User>(options =>
               {
                   options.Password.RequireDigit = false;
                   options.Password.RequireLowercase = false;
                   options.Password.RequireNonAlphanumeric = false;
                   options.Password.RequireUppercase = false;
               })
               .AddRoles<IdentityRole>()
               .AddEntityFrameworkStores<GlassesDbContext>();

            services.AddAutoMapper(typeof(Startup));

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
            });

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IGlassesService, GlassesService>();
            services.AddTransient<IBrandService, BrandService>();
            services.AddTransient<IGlassesTypeService, GlassesTypeService>();
            services.AddTransient<ICardService, CardService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<ILikeService, LikeService>();
            services.AddTransient<IUserSeedService, UserSeedService>();
            services.AddTransient<IGlassesTypeSeedService, GlassesTypeSeedService>();
            services.AddTransient<ICardTypeSeedService, CardTypeSeedService>();
            services.AddTransient<IBrandSeedService, BrandSeedService>();
            services.AddTransient<IGlassesSeedService, GlassesSeedService>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<IContactMessageSeedService, ContactMessageSeedService>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            var cultureInfo = new CultureInfo("en-US");
            cultureInfo.NumberFormat.NumberGroupSeparator = ",";

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            app.PrepareDatabase();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultAreaRoute();
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
        }
    }
}
