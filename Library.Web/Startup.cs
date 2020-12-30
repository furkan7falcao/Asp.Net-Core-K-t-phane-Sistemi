using System;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Library.Entities.Concreate;
using Library.Web.CustomValidator;
using Library.DataAccess.Concreate.EntityFrameworkCore.Context;
using Library.Business.Containers.MicrosoftIOC;

namespace Library.Web
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
            services.AddMvc();

            services.AddIdentity<Member, Role>(opt =>
            {
                opt.Password.RequiredLength = 7;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = true;
                opt.Password.RequireUppercase = false;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(10);//10 dk kitle
                opt.Lockout.MaxFailedAccessAttempts = 3;//max 3 yanlýþ giriþ hakký
                opt.SignIn.RequireConfirmedEmail = false;

            }).AddPasswordValidator<CustomPasswordValidator>()
              .AddErrorDescriber<CustomIdentityValidator>()
              .AddEntityFrameworkStores<ApplicationDbContext>();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.Name = "MyCookie";
                opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                opt.Cookie.HttpOnly = true; // document yazarak cookie'ye ulaþamasýn
                opt.ExpireTimeSpan = TimeSpan.FromDays(20);
                opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
                opt.LoginPath = new PathString("/Home/SignIn");
            });



            services.AddDbContext<ApplicationDbContext>();
            services.AddAutoMapper(typeof(Startup));
            services.AddDependency();
            services.AddControllersWithViews().AddFluentValidation();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<Member> userManager, RoleManager<Role> roleManager)
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

            IdentityInitializer.SeedData(userManager, roleManager).Wait();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area}/{controller=Home}/{action=Index}/{id?}"
                    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=SignIn}/{id?}");
            });
        }

    }
}
