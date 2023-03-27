using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using bookshop.data.Concrete.EfCore;
using bookshop.webui.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using bookshop.business.Abstract;
using bookshop.business.Concrete;
using bookshop.data.Abstract;
using bookshop.data.Concrete;
using bookshop.webui.EmailServices;



namespace bookshop.webui
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseSqlite(_configuration.GetConnectionString("SqliteConnection")));
            services.AddDbContext<ShopContext>(options => options.UseSqlite(_configuration.GetConnectionString("SqliteConnection")));
            // services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(_configuration.GetConnectionString("MsSqlConnection")));
            // services.AddDbContext<ShopContext>(options => options.UseSqlServer(_configuration.GetConnectionString("MsSqlConnection")));
            // services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
            // services
            //     .AddDbContext<ApplicationContext>(options =>
            //         options.UseSqlite("Data Source=bookDb"));
            services
                .AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();

            services
                .Configure<IdentityOptions>(options =>
                {
                    //    password
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireNonAlphanumeric = true;

                    // Lockout
                    options.Lockout.MaxFailedAccessAttempts = 6;
                    options.Lockout.DefaultLockoutTimeSpan =
                        TimeSpan.FromMinutes(5);
                    options.Lockout.AllowedForNewUsers = true;

                    // options.User.AllowedUserNameCharacters ="";
                    options.User.RequireUniqueEmail = true;
                    options.SignIn.RequireConfirmedEmail = true;
                    options.SignIn.RequireConfirmedPhoneNumber = false;
                });

            services
                .ConfigureApplicationCookie(options =>
                {
                    options.LoginPath = "/account/login";
                    options.LogoutPath = "/account/logout";
                    options.AccessDeniedPath = "/account/accessdenied";
                    options.SlidingExpiration = true;
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(120);
                    options.Cookie =
                        new CookieBuilder {
                            HttpOnly = true,
                            Name = ".BookApp.Security.Cookie",
                            SameSite = SameSiteMode.Strict
                        };
                });

            // services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
            // services.AddScoped<IProductRepository, EfCoreProductRepository>();
            // services.AddScoped<ICartRepository, EfCoreCartRepository>();
            // services.AddScoped<IOrderRepository, EfCoreOrderRepository>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IAuthorService,AuthorManager>();
            services.AddScoped<IPublisherService,PublisherManager>();
            services.AddScoped<ITranslatorService,TranslatorManager>();
            services.AddScoped<ICartService, CartManager>();
            services.AddScoped<IOrderService, OrderManager>();


            services
                .AddScoped<IEmailSender, SmtpEmailSender>(i =>
                    new SmtpEmailSender(_configuration["EmailSender:Host"],
                        _configuration.GetValue<int>("EmailSender:Port"),
                        _configuration.GetValue<bool>("EmailSender:EnableSSL"),
                        _configuration["EmailSender:UserName"],
                        _configuration["EmailSender:Password"]));

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IConfiguration configuration,UserManager<User> userManager, RoleManager<IdentityRole> roleManager,ICartService cartService)
        {
            // wwwroot
            app.UseStaticFiles();
            app
                .UseStaticFiles(new StaticFileOptions {
                    FileProvider =
                        new PhysicalFileProvider(Path
                                .Combine(Directory.GetCurrentDirectory(),
                                "node_modules")),
                    RequestPath = "/modules"
                });

            if (env.IsDevelopment())
            {
                
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            // localhost:5000
            // localhost:5000/home
            // localhost:5000/product/details/2
            // localhost:5000/product/list/3
            app
                .UseEndpoints(endpoints =>
                {
                    endpoints
                        .MapControllerRoute(name: "orders",
                        pattern: "orders",
                        defaults: new {
                            controller = "Cart",
                            action = "GetOrders"
                        });
                     endpoints
                        .MapControllerRoute(name: "checkout",
                        pattern: "checkout",
                        defaults: new {
                            controller = "Cart",
                            action = "Checkout"
                        });
                     endpoints
                        .MapControllerRoute(name: "cart",
                        pattern: "cart",
                        defaults: new {
                            controller = "Cart",
                            action = "Index"
                        });
                    endpoints
                        .MapControllerRoute(name: "adminusers",
                        pattern: "admin/user/list",
                        defaults: new {
                            controller = "Admin",
                            action = "UserList"
                        });
                         endpoints
                        .MapControllerRoute(name: "adminuseredit",
                        pattern: "admin/user/{id?}",
                        defaults: new {
                            controller = "Admin",
                            action = "UserEdit"
                        });
                    endpoints
                        .MapControllerRoute(name: "adminroles",
                        pattern: "admin/role/list",
                        defaults: new {
                            controller = "Admin",
                            action = "RoleList"
                        });
                         endpoints
                        .MapControllerRoute(name: "adminrolecreate",
                        pattern: "admin/role/create",
                        defaults: new {
                            controller = "Admin",
                            action = "RoleCreate"
                        });
                         endpoints
                        .MapControllerRoute(name: "adminroleedit",
                        pattern: "admin/role/{id?}",
                        defaults: new {
                            controller = "Admin",
                            action = "RoleEdit"
                        });
                    endpoints
                        .MapControllerRoute(name: "adminproducts",
                        pattern: "admin/products",
                        defaults: new {
                            controller = "Admin",
                            action = "ProductList"
                        });
                            endpoints
                                .MapControllerRoute(name: "adminauthors",
                                pattern: "admin/authors",
                                defaults: new {
                                    controller = "Admin",
                                    action = "AuthorList"
                                });
                             endpoints
                                .MapControllerRoute(name: "adminpublishers",
                                pattern: "admin/publishers",
                                defaults: new {
                                    controller = "Admin",
                                    action = "PublisherList"
                                });
                            endpoints
                                .MapControllerRoute(name: "admintranslators",
                                pattern: "admin/translators",
                                defaults: new {
                                    controller = "Admin",
                                    action = "TranslatorList"
                                });
                    endpoints
                        .MapControllerRoute(name: "adminproductcreate",
                        pattern: "admin/products/create",
                        defaults: new {
                            controller = "Admin",
                            action = "ProductCreate"
                        });
                                    endpoints
                                            .MapControllerRoute(name: "adminauthorcreate",
                                            pattern: "admin/authors/create",
                                            defaults: new {
                                                controller = "Admin",
                                                action = "AuthorCreate"
                                            });
                                    endpoints
                                            .MapControllerRoute(name: "adminpublishercreate",
                                            pattern: "admin/publishers/create",
                                            defaults: new {
                                                controller = "Admin",
                                                action = "PublisherCreate"
                                            });
                                     endpoints
                                            .MapControllerRoute(name: "admintranslatorcreate",
                                            pattern: "admin/translators/create",
                                            defaults: new {
                                                controller = "Admin",
                                                action = "TranslatorCreate"
                                            });
                    endpoints
                        .MapControllerRoute(name: "adminproductedit",
                        pattern: "admin/products/{id?}",
                        defaults: new {
                            controller = "Admin",
                            action = "ProductEdit"
                        });

                                                endpoints
                                                    .MapControllerRoute(name: "adminauthoredit",
                                                    pattern: "admin/authors/{id?}",
                                                    defaults: new {
                                                        controller = "Admin",
                                                        action = "AuthorEdit"
                                                    });
                                                 endpoints
                                                    .MapControllerRoute(name: "adminpublisheredit",
                                                    pattern: "admin/publishers/{id?}",
                                                    defaults: new {
                                                        controller = "Admin",
                                                        action = "PublisherEdit"
                                                    });  
                                                 endpoints
                                                    .MapControllerRoute(name: "admintranslatoredit",
                                                    pattern: "admin/translators/{id?}",
                                                    defaults: new {
                                                        controller = "Admin",
                                                        action = "TranslatorEdit"
                                                    });   
                    endpoints
                        .MapControllerRoute(name: "admincategories",
                        pattern: "admin/categories",
                        defaults: new {
                            controller = "Admin",
                            action = "CategoryList"
                        });
                    endpoints
                        .MapControllerRoute(name: "admincategorycreate",
                        pattern: "admin/categories/create",
                        defaults: new {
                            controller = "Admin",
                            action = "CategoryCreate"
                        });
                    endpoints
                        .MapControllerRoute(name: "admincategoryedit",
                        pattern: "admin/categories/{id?}",
                        defaults: new {
                            controller = "Admin",
                            action = "CategoryEdit"
                        });
                                     endpoints
                                            .MapControllerRoute(name: "authorlist",
                                            pattern: "author/list",
                                            defaults: new { controller = "Author", action = "list" });

                                            endpoints
                                            .MapControllerRoute(name: "authordetails",
                                            pattern: "author/details/{url?}",
                                            defaults: new { controller = "Author", action = "details" });
                                    endpoints
                                            .MapControllerRoute(name: "publisherslist",
                                            pattern: "publisher/list",
                                            defaults: new { controller = "Publisher", action = "list" });

                                            endpoints
                                            .MapControllerRoute(name: "publisherdetails",
                                            pattern: "publisher/details/{url?}",
                                            defaults: new { controller = "Publisher", action = "details" });
                                    

                                            endpoints
                                            .MapControllerRoute(name: "translatordetails",
                                            pattern: "translator/details/{url?}",
                                            defaults: new { controller = "Translator", action = "details" });


                                       

                    endpoints
                        .MapControllerRoute(name: "search",
                        pattern: "search",
                        defaults: new {
                            controller = "Shop",
                            action = "search"
                        });
                    endpoints
                        .MapControllerRoute(name: "productdetails",
                        pattern: "{url}",
                        defaults: new {
                            controller = "Shop",
                            action = "details"
                        });
                                           
                    endpoints
                        .MapControllerRoute(name: "products",
                        pattern: "products/{category?}",
                        defaults: new { controller = "Shop", action = "list" });

                    endpoints
                        .MapControllerRoute(name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
                });
                
                SeedIdentity.Seed(userManager,roleManager,cartService,configuration).Wait();
        }
    }
}
