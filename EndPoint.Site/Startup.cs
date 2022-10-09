using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MyStore.Persistence.Contexts;
using MyStore.Application.Interfaces.Contexts;
using MyStore.Application.Services.Users.Queries.GetUsers;
using MyStore.Application.Services.Users.Queries.GetRoles;
using MyStore.Application.Services.Users.Commands.RgegisterUser;
using MyStore.Application.Services.Users.Commands.RemoveUser;
using MyStore.Application.Services.Users.Commands.UserLogin;
using MyStore.Application.Services.Users.Commands.UserSatusChange;
using MyStore.Application.Services.Users.Commands.EditUser;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using MyStore.Application.Interfaces.FacadPatterns;
using MyStore.Application.Services.Products.FacadPattern;
using MyStore.Application.Services.Common.Queries.GetMenuItem;
using MyStore.Application.Services.Common.Queries.GetCategory;
using MyStore.Application.Services.HomePages.AddNewSlider;
using Microsoft.Extensions.Hosting.Internal;
using MyStore.Application.Services.Common.Queries.GetSlider;
using MyStore.Application.Services.HomePages.AddHomePageImages;
using MyStore.Application.Services.Common.Queries.GetHomePageImages;
using MyStore.Application.Services.Carts;
using MyStore.Application.Services.Fainances.Commands.AddRequestPay;
using MyStore.Common.Roles;
using MyStore.Application.Services.Fainances.Queries.GetRequestPayService;
using MyStore.Application.Services.Orders.Commands.AddNewOrder;
using MyStore.Application.Services.Orders.Queries.GetUserOrders;
using MyStore.Application.Services.Orders.Queries.GetOrdersForAdmin;
using MyStore.Application.Services.Fainances.Queries.GetRequestPayForAdmin;

namespace EndPoint.Site
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

            services.AddAuthorization(options =>
            {
                options.AddPolicy(UserRoles.Admin, policy => policy.RequireRole(UserRoles.Admin));
                options.AddPolicy(UserRoles.Customer, policy => policy.RequireRole(UserRoles.Customer));
                options.AddPolicy(UserRoles.Operator, policy => policy.RequireRole(UserRoles.Operator));
            });

            services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = new PathString("/Authentication/Signin");
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
                options.AccessDeniedPath = new PathString("/Authentication/Signin");
            });


            services.AddScoped<IDataBaseContext, DataBaseContext>();
            services.AddScoped<IGetUsersService,  GetUsersService>();
            services.AddScoped<IGetRolesService,  GetRolesService>();
            services.AddScoped<IRegisterUserService,  RegisterUserService>();
            services.AddScoped<IRemoveUserService,  RemoveUserService>();
            services.AddScoped<IUserLoginService, UserLoginService>();
            services.AddScoped<IUserSatusChangeService,  UserSatusChangeService>();
            services.AddScoped<IEditUserService,  EditUserService>();

            //FacadeInject
            services.AddScoped<IProductFacad, ProductFacad>();


            //------------------
            services.AddScoped<IGetMenuItemService, GetMenuItemService>();
            services.AddScoped<IGetCategoryService, GetCategoryService>();
            services.AddScoped<IAddNewSliderService,  AddNewSliderService>();
            services.AddScoped<IGetSliderService, GetSliderService>();
            services.AddScoped<IAddHomePageImagesService,  AddHomePageImagesService>();
            services.AddScoped<IGetHomePageImagesService, GetHomePageImagesService>();

            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IAddRequestPayService, AddRequestPayService>();
            services.AddScoped<IGetRequestPayService,  GetRequestPayService>();
            services.AddScoped<IAddNewOrderService,  AddNewOrderService>();
            services.AddScoped<IGetUserOrdersService,  GetUserOrdersService>();
            services.AddScoped<IGetOrdersForAdminService,  GetOrdersForAdminService>();
            services.AddScoped<IGetRequestPayForAdminService,  GetRequestPayForAdminService>();




            //string contectionString = @"Data Source=.;Initial Catalog = MyStoreDb;Integrated Security=True;";
            string contectionString = @"Data Source = 148.251.162.201,2019;Initial Catalog = MYSTORE;Persist Security Info = True;User ID = humn1997;Password = EaG@3233714";
            services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(option => option.UseSqlServer(contectionString));
            services.AddControllersWithViews();
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //   name: "areas",
                //   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                   name: "areas",
                   areaName:"Admin",
                   pattern: "Admin/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                   name: "areas",
                   areaName:"Customer",
                   pattern: "Customer/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
