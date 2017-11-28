
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using EFDataApp2.Models;
using EFDataApp2.Infrastructure;


namespace EFDataApp2
{
    public class Startup
    {
        // Старая рабочая реализация, необходимая для публикации БД: Identity и mobilesdb
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        // Старая рабочая реализация, необходимая для публикации БД: Identity и mobilesdb
        // public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // Старая рабочая реализация, необходимая для публикации БД: Identity и mobilesdb
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    получаем строку подключения из файла конфигурации
        // string connection = Configuration.GetConnectionString("DefaultConnection");
        // добавляем контекст MobileContext в качестве сервиса в приложение
        //  services.AddDbContext<MobileContext>(options =>
        //      options.UseSqlServer(connection));

        // string connection2 = Configuration.GetConnectionString("ConnectionString");
        //     options.UseSqlServer(connection));

        // services.AddDbContext<AppIdentityDbContext>(options =>
        //options.UseSqlServer(Configuration["Data:MDSIdentity:ConnectionString"]));

        //  services.AddIdentity<IdentityUser, IdentityRole>()
        //    .AddEntityFrameworkStores<AppIdentityDbContext>();
        //   services.AddMvc();
        //  }
        IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IPasswordValidator<MDSUser>,
            CustomPasswordValidator>();
            services.AddTransient<IUserValidator<MDSUser>,
            CustomUserValidator>();

            services.AddDbContext<MDSIdentityDbContext>(options =>
            options.UseSqlServer(
            Configuration["Data:MDSIdentity:ConnectionString"]));
          
           // Ниже закомментирована установка базовой схема требавоний к паролям (по умолчанию)
           //  services.AddIdentity<MDSUser, IdentityRole>()
           //      .AddEntityFrameworkStores<MDSIdentityDbContext>();

            services.AddIdentity<MDSUser, IdentityRole>(opts => {

                opts.User.RequireUniqueEmail = true;
          //      opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz0123456789";
                
                opts.Password.RequiredLength = 8;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = true;
                opts.Password.RequireUppercase = true;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<MDSIdentityDbContext>();


            services.AddMvc();
        }   
    
        public void Configure(IApplicationBuilder app)
        {

            app.UseStatusCodePages();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseBrowserLink();
            app.UseMvcWithDefaultRoute();
            app.UseIdentity();

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});
        }
    }
}
