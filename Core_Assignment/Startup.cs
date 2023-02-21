using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using BusinessLayer.Dependency;
using BusinessLayer.Dependency.IDependency;
using DataaccessLayer;
using DataaccessLayer.Dependency;
using DataaccessLayer.Dependency.IDependency;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Core_Assignment
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

            services.AddNotyf(config => { config.DurationInSeconds = 1; config.IsDismissable = true; config.Position = NotyfPosition.TopRight; });
            services.AddControllersWithViews();
            services.AddDbContextPool<ProductDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.ExpireTimeSpan = TimeSpan.FromMinutes(60 * 1);
                    option.LoginPath = "/Account/Login";
                    option.AccessDeniedPath = "/Account/Login";
                });

            services.AddSession(option =>
              {
               option.IdleTimeout = TimeSpan.FromMinutes(10);
               option.Cookie.HttpOnly = true;
               option.Cookie.IsEssential = true;
              }
              );

            //Dependency Injection
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
          
            services.AddScoped<IProductDAL, ProductDAL>();

            services.AddScoped<IProductBL, ProductBL>();

            services.AddScoped<ICategoryDAL, CategoryDAL>();

            services.AddScoped<ICategoryBL, CategoryBL>();

            services.AddScoped<IAccountDAL, AccountDAL>();

            services.AddScoped<IAccountBL, AccountBL>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseNotyf();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();
            app.UseAuthorization();
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
