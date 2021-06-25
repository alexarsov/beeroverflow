using BeerOverflow.Services.Services.Help_Services;
using BeerOverflow.Services.Services.Main_Services;
using Microsoft.Extensions.DependencyInjection;
using BeerOverflow.Data.DataAccessContext;
using Microsoft.Extensions.Configuration;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using BeerOverflow.Data.Entities;
using BeerOverflow.Services;
using Newtonsoft.Json;
using NToastNotify;

namespace BeerOverflow.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            });

            services.AddDbContext<BeerOverflowContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<Role>()
                .AddEntityFrameworkStores<BeerOverflowContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation().AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

            services.AddMvc().AddNToastNotifyToastr(new ToastrOptions()
            {
                ProgressBar = false,
                PositionClass = ToastPositions.BottomRight
            });

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBanService, BanService>();
            services.AddScoped<IBeerService, BeerService>();
            services.AddScoped<IBreweryService, BreweryService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IDrankListService, DrankListService>();
            services.AddScoped<IFilterBeerService, FilterBeerService>();
            services.AddScoped<IReviewBeerService, ReviewBeerService>();
            services.AddScoped<ISortBeerService, SortBeerService>();
            services.AddScoped<IStyleService, StyleService>();
            services.AddScoped<IWishListService, WishListService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseNToastNotify();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();

                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area=exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
